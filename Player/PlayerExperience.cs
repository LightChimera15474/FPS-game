using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExperience : MonoBehaviour
{
    [Header("UI params")]
    [SerializeField] private TextMeshProUGUI _playerLevelText;
    [SerializeField] private Image _frontExpBar;
    [SerializeField] private Image _backExpBar;
    [SerializeField] private float _chipSpeed = 1;

    private float _learpTimer;
    private int _playerLevel = 1;
    private float _playerExp = 0;
    private float _needExpToNextLevel = 100;
    private float _expLeftToLevelUp;

    public int PlayerLevel { get => _playerLevel; }

    private void Start()
    {
        _expLeftToLevelUp = _needExpToNextLevel;
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        var fillFront = _frontExpBar.fillAmount;
        var expFraction = _playerExp / _needExpToNextLevel;

        if (fillFront < expFraction) 
        {
            _backExpBar.fillAmount = expFraction;
            _learpTimer = Time.deltaTime;
            var procentComplite = _learpTimer / _chipSpeed;
            _frontExpBar.fillAmount = Mathf.Lerp(fillFront, expFraction, procentComplite);
        }

        _playerLevelText.text = _playerLevel.ToString();
    }

    public void AddExp(float exp)
    {
        if (exp < _expLeftToLevelUp)
        {
            _expLeftToLevelUp -= exp;
            _playerExp += exp;
        }
        else
        {
            LevelUp();
            var tmpExp = exp - _expLeftToLevelUp;
            _expLeftToLevelUp = _needExpToNextLevel;
            _playerExp += tmpExp;
            _expLeftToLevelUp -= tmpExp;
        }
        _learpTimer = 0;
    }

    private void LevelUp()
    {
        _playerLevel += 1;
        _needExpToNextLevel += _needExpToNextLevel / 5;
        _playerExp = 0;

        // востановление здоровья на максимум.
        GetComponent<PlayerHealth>().RestoreHealth(GetComponent<PlayerHealth>().MaxHealth);

        _frontExpBar.fillAmount = 0;
        _backExpBar.fillAmount = 0;
    }
}
