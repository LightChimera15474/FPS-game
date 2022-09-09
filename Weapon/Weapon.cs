using System;
using System.Collections;
using UnityEngine;

public enum BulletImpuctEffect
{
    BloodBig = 0,
    BloodSmall = 1,
    Sand = 2,
    Stone = 3,
    WaterContainer = 4,
    Wood = 5,
}

public class Weapon : MonoBehaviour
{
    [Header("Main Params")]
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _mask;

    [Header("Shooting Effects")]
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject[] _impuctEffects;
    [SerializeField] private float _impuctForce;

    [Header("Audio Effects")]
    [SerializeField] private AudioClip _shootAudio;
    [SerializeField] private AudioClip _reloadClip;
 
    private float _lastShootingTime = 0;

    private void Awake()
    {
        PlayerInputs.ShootActions += Shoot;
        PlayerInputs.ReloadAction += Reloading;
    }

    private void Start()
    {
        _weaponData.CurrentAmmo = _weaponData.ClipSize;
        _weaponData.IsReloading = false;
        _weaponData.IsAiming = false;
    }

    private void Update()
    {
        _lastShootingTime += Time.deltaTime;
    }

    public void Shoot()
    {
        if (CanShoot())
        {
            ShootEffectPlay();
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, _weaponData.MaxDistance, _mask))
            {
                var enemyHealth = hit.transform.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(_weaponData.Damage);
                }
                var enemyRB = hit.transform.GetComponent<Rigidbody>();
                if (enemyRB != null)
                {
                    enemyRB.AddForce(-hit.normal * _impuctForce, ForceMode.Impulse);
                }
                CreateBulletImpuct(hit);
            }
            _weaponData.CurrentAmmo -= 1;
            _lastShootingTime = 0;
            PlayerUI.UpdateAllAction.Invoke();
        }
    }

    
    private void Reloading()
    {
        if (!_weaponData.IsReloading && _weaponData.CurrentAmmo < _weaponData.ClipSize)
        {
            StartCoroutine(ReloadingProcess());
        }
    }

    private IEnumerator ReloadingProcess()
    {
        _weaponData.IsReloading = true;
        yield return new WaitForSeconds(_weaponData.ReloadingTime);

        _weaponData.CurrentAmmo = _weaponData.ClipSize;
        _weaponData.IsReloading = false;
        PlayerUI.UpdateAllAction.Invoke();
    }


    private void ShootEffectPlay()
    {
        _muzzleFlash.Play();
        GetComponent<AudioSource>().PlayOneShot(_shootAudio);
    }

    private void CreateBulletImpuct(RaycastHit hit)
    {
        var tag = hit.transform.tag;
        GameObject impuctEffect;
        switch (tag)
        {
            case "Meet":
                impuctEffect = _impuctEffects[(int)BulletImpuctEffect.BloodBig];
                break;
            case "Sand":
                impuctEffect = _impuctEffects[(int)BulletImpuctEffect.Sand];
                break;
            case "Stone":
                impuctEffect = _impuctEffects[(int)BulletImpuctEffect.Stone];
                break;
            case "WaterConteiner":
                impuctEffect = _impuctEffects[(int)BulletImpuctEffect.WaterContainer];
                break;
            case "Wood":
                impuctEffect = _impuctEffects[(int)BulletImpuctEffect.Wood];
                break;
            default:
                impuctEffect = _impuctEffects[(int)BulletImpuctEffect.Stone];
                break;
        }

        var parent = hit.transform.GetComponent<Transform>();
        var effect = Instantiate(impuctEffect, hit.point, Quaternion.LookRotation(hit.normal));
        effect.transform.SetParent(parent);
    }

    private bool CanShoot()
    {
        return _weaponData.CurrentAmmo > 0 && !_weaponData.IsReloading && (_lastShootingTime > 1 / (_weaponData.FireRate / 60));
    }
}
