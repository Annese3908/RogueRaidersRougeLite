using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Interface thqat other scripts can implement to make objects interactable
public interface Interactable
{
    void Interact();

    void Target();
}
