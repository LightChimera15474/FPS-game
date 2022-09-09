using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Bar")]
    [SerializeField] private Image _backHealthBar;
    [SerializeField] private Image _frontHealthBar;
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _chipSpeed;

    private float _learpTimer;
    private float _health;

    [Header("Damage Effect")]
    [SerializeField] private Image _damageEffect;
    [SerializeField] private float _duration;
    [SerializeField] private float _fadeSpeed;

    private float _durationTime = 0;

    public float MaxHealth { get => _maxHealth; }
    public float Health { get => _health; }

    private void Start()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        UpdateHealthUI();
        DamageEffectsUpdate();
    }

    private void DamageEffectsUpdate()
    {
        if (_damageEffect.color.a > 0)
        {
            if (_health <= _maxHealth * 0.3f)
            {
                return;
            }
            _durationTime += Time.deltaTime;
            if (_durationTime > _duration)
            {
                var tmpAlpha = _damageEffect.color.a;
                tmpAlpha -= Time.deltaTime * _fadeSpeed;
                _damageEffect.color = new Color(_damageEffect.color.r, _damageEffect.color.g, _damageEffect.color.b, tmpAlpha);
            }
        }
    }

    private void UpdateHealthUI()
    {
        var fillFront = _frontHealthBar.fillAmount;
        var fillBack = _backHealthBar.fillAmount;
        var healthFraction = _health / _maxHealth;

        if (fillBack > healthFraction)
        {
            _frontHealthBar.fillAmount = healthFraction;
            _backHealthBar.color = Color.red;
            _learpTimer = Time.deltaTime;
            var precentComplite = _learpTimer / _chipSpeed;
            _backHealthBar.fillAmount = Mathf.Lerp(fillBack, healthFraction, precentComplite);
        }
        else if (fillFront < healthFraction)
        {
            _backHealthBar.color = Color.green;
            _backHealthBar.fillAmount = healthFraction;
            _learpTimer = Time.deltaTime;
            var precentComplite = _learpTimer / _chipSpeed;
            _frontHealthBar.fillAmount = Mathf.Lerp(fillFront, healthFraction, precentComplite);
        }
    }

    public void TakeDamage(float damege)
    {
        _health -= damege;
        _learpTimer = 0;
        if (_health <= 0)
        {
            Die();
        }
        _durationTime = 0;
        _damageEffect.color = new Color(_damageEffect.color.r, _damageEffect.color.g, _damageEffect.color.b, 0.7f);
    }

    public void RestoreHealth(float healAmount)
    {
        _health += healAmount;
        _learpTimer = 0;
    }

    private void Die()
    {
        SceneManager.LoadScene(0);
    }
}
