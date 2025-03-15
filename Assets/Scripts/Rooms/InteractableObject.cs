using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class InteractableObject : MonoBehaviour, Interactable
{
    [SerializeField]
    private SpriteRenderer promptSprite;

    protected bool isTarget;
    protected bool isInteractable;

    [HideInInspector]
    public bool interacted;

    public abstract void Interact();

    public void Target(bool targeted)
    {
        //Debug.Log(gameObject.name + " targeted: " + targeted);
        isTarget = targeted;
    }

    public bool IsTargeted()
    {
        return isTarget;
    }

    public bool IsInteractable()
    {
        return isInteractable;
    }

    public virtual void Update()
    {
        promptSprite.enabled = isInteractable && isTarget;
    }
}
