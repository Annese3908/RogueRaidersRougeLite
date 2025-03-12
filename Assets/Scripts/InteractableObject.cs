using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class InteractableObject : MonoBehaviour, Interactable
{
    [SerializeField] protected Player player;
    protected bool isInteractable;

    public abstract void Interact();

    public virtual void Update()
    {
        if (isInteractable & Input.GetKeyDown("space"))
        {
            Interact();
        }
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        //is interactable if player is in trigger

        if (other.GetComponent<Player>() == null) //stops function if collider is not the player
            return;

        isInteractable = true;
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        //is not interactable if player leaves trigger

        if (isInteractable)
        {
            if (other.GetComponent<Player>() != null)
                isInteractable = false;
        }
    }
}
