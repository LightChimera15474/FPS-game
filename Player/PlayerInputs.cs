using System;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public static Action ShootActions;
    public static Action ReloadAction;
 
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            ShootActions?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadAction?.Invoke();
        }
    }
}
