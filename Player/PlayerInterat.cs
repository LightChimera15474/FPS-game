using System;
using UnityEngine;

public class PlayerInterat : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private Camera _camera;
    
    private PlayerUI _playerUI;

    private void Start()
    {
        _playerUI = GetComponent<PlayerUI>();
    }

    private void Update()
    {
        _playerUI.PromtMessageUpdate(string.Empty);

        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, _distance, _mask))
        {
            var interact = hit.transform.GetComponent<Interactable>();
            if (interact != null)
            {
                _playerUI.PromtMessageUpdate(interact.Message);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    hit.transform.GetComponent<Interactable>().BaseInteract();
                }
            }
        }
    }
}
