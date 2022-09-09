using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : Interactable
{
    [SerializeField] private Material _lightOn;
    [SerializeField] private Material _lightOff;
    [SerializeField] private Light _light;

    private bool _clickOn = true;

    protected override void Interact()
    {
        if (_clickOn)
        {
            GetComponent<MeshRenderer>().material = _lightOn;
            Message = "Выключить";
            _light.gameObject.SetActive(true);
        }
        else
        {
            GetComponent<MeshRenderer>().material = _lightOff;
            Message = "Включить";
            _light.gameObject.SetActive(false);
        }
        _clickOn = !_clickOn;
    }

}
