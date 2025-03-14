using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class InteractableObject : MonoBehaviour, Interactable
{
    [SerializeField]
    private SpriteRenderer promptSprite;
    [SerializeField]
    private float promptDuration = .25f;
    private float timeUntargeted = 0;

    protected bool isTarget;
    protected bool isInteractable;

    public abstract void Interact();

    public void Target()
    {
        isTarget = true;
        timeUntargeted = 0;
    }

    public virtual void Update()
    {
        //untarget object if prompt duration ends
        if (timeUntargeted < promptDuration)
        {
            timeUntargeted += Time.deltaTime;
        }
        else
        {
            isTarget = false;
        }

        promptSprite.enabled = isInteractable;
    }
}
