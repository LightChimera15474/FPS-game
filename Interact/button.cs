using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : Interactable
{
    [SerializeField] private GameObject _button;
    [SerializeField] private GameObject _door;

    private bool _isOpenning = true;

    protected override void Interact()
    {
        if (_isOpenning)
        {
            _button.GetComponent<Animation>().Play("Button open");
            _door.GetComponent<Animation>().Play("open Door");
        }
        else
        {
            _button.GetComponent<Animation>().Play("Button close");
            _door.GetComponent<Animation>().Play("close Door");
        }
        _isOpenning = !_isOpenning;
    }
}
