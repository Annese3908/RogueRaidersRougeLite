using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, Interactable
{
    //
    public void Interact()
    {
        Debug.Log("Object Interacted with!");
    }
}
