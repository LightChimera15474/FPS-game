using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : Interactable
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _spawnPoint;

    protected override void Interact() 
    {
        Instantiate(_gameObject, _spawnPoint);    
    }
}
