using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapon Data", order = 51)]
public class WeaponData : ScriptableObject
{
    [Header("Information")]
    [SerializeField] private string _name;
    [SerializeField] private string _weaponType;
    [SerializeField] private string _discription;
    [SerializeField] private Image _weaponImage;

    [Header("Shooting")]
    [SerializeField] private float _fireRate;
    [SerializeField] private float _maxDistance;
    [SerializeField] private int _damage;

    [Header("Reloading")]
    [SerializeField] private int _currentAmmo;
    [SerializeField] private int _clipSize;
    [SerializeField] private float _reloadingTime;

    [HideInInspector]
    [SerializeField] private bool _isReloading = false;
    [HideInInspector]
    [SerializeField] private bool _isAiming = false;

    public string Name { get => _name; }
    public string WeaponType { get => _weaponType; }
    public string Discription { get => _discription; set => _discription = value; }
    public float FireRate { get => _fireRate; }
    public float MaxDistance { get => _maxDistance; }
    public int Damage { get => _damage; set => _damage = value; }
    public int CurrentAmmo { get => _currentAmmo; set => _currentAmmo = value; }
    public int ClipSize { get => _clipSize; set => _clipSize = value; }
    public float ReloadingTime { get => _reloadingTime; set => _reloadingTime = value; }
    public bool IsReloading { get => _isReloading; set => _isReloading = value; }
    public Image WeaponImage { get => _weaponImage; set => _weaponImage = value; }
    public bool IsAiming { get => _isAiming; set => _isAiming = value; }
}
