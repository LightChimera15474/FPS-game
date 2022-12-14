using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool UseEvents;
    public string Message;

    public void BaseInteract()
    {
        if (UseEvents)
        {
            GetComponent<InteractionEvents>().OnInteract.Invoke();
        }
        Interact();
    }

    protected virtual void Interact()
    {
        
    }
}
