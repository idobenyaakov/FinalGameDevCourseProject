using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvenet;
    [SerializeField] public string promptMessage;

    public virtual string OnLook() 
    { 
        return promptMessage; 
    }
    public void BaseInteract()
    {
        if(useEvenet)
        {
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }
        Interact();
    }
    protected virtual void Interact()
    {

    }
}
