using System;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public static Action UpdateAllAction;

    [Header("UI elements")]
    [SerializeField] private TextMeshProUGUI _promtText;
    [SerializeField] private TextMeshProUGUI _currentAmmoText;

    [Header("References to objects")]
    [SerializeField] private WeaponData _weaponData;

    [Header("Message")]
    [SerializeField] private string _reloadMessage = "Перезарядка...";

    private void Awake()
    {
        PlayerInputs.ReloadAction += ReloadingMessage;
        UpdateAllAction += CurrentAmmoUpdate;
    }

    public void PromtMessageUpdate(string message)
    {
        _promtText.text = message;
    }

    private void ReloadingMessage()
    {
        if (_weaponData.IsReloading)
        {
            _currentAmmoText.text = _reloadMessage;
        }
    }

    private void CurrentAmmoUpdate()
    {
        _currentAmmoText.text = _weaponData.CurrentAmmo.ToString();
    }
}
