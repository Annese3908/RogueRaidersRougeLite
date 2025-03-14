using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // distance in which the player can interact with an object
    public Interactable obj;

    public void Update()
    {
        //if there is a targeted object, and the interact key is pressed, interact with object
        if (obj != null & Input.GetKeyDown(KeyCode.E))
        {
            obj.Interact();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //exit function if object is not interactable object
        if (!other.CompareTag("Interactable"))
            return;

        Interactable newObject = other.GetComponent<Interactable>();

        //exit function if new object is not interactable
        if (!newObject.IsInteractable())
            return;

        //if an object is already targeted, untarget it
        if (obj != null)
            obj.Target(false);

        //target new object
        obj = newObject;
        obj.Target(true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        //exit function if object is not interactable object
        if (!other.CompareTag("Interactable"))
            return;

        Interactable newObject = other.GetComponent<Interactable>();

        //if targeted object exited, untarget it 
        if (newObject == obj)
        {
            obj = null;
            newObject.Target(false);
        }
    }
}
