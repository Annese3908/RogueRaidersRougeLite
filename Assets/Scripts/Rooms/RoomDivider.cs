using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDivider : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Collider2D barrier;



    public void Toggle(bool open)
    {
        barrier.enabled = open;

        animator.SetBool("Grow", open);
    }

    private void Awake()
    {
        Toggle(false);
    }
}
