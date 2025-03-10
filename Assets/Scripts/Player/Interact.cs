using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // distance in which the player can interact with an object
    public float interactDistance = 3f;

    //layer mask to specify which objects are interactable
    public LayerMask interactableLayer;

    // Update is called once per frame
    void Update()
    {
        // check if the E key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }
    }

    void InteractWithObject()
    {
        RaycastHit hit;

        // send a raycast from the players position foward to detect interactable object
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactableLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                // call the interact method on the interactable object
                interactable.Interact();
            }
        }
    }
}
