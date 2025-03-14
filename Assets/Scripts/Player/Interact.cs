using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // distance in which the player can interact with an object
    public float interactDistance = 3f;

    private void FixedUpdate()
    {
        InteractWithObject(FindInteracable());
    }

    private void InteractWithObject(Interactable interactable)
    {
        if (interactable == null)
            return;

        //tell object that it is targeted for interaction
        interactable.Target();

        // check if the E key is pressed
        if (Input.GetKeyDown(KeyCode.E))
            interactable.Interact();
    }

    private Interactable FindInteracable()
    {
        RaycastHit hit;

        // send a raycast from the players position foward to detect interactable object
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance))
        {
            //return interactable script if object is interactable
            if (hit.collider.CompareTag("Interactables"))
                return hit.collider.GetComponent<Interactable>();
        }
        return null;
    }
}
