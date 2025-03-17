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
    [SerializeField]
    private AudioSource audioPlayer;



    public void Toggle(bool open)
    {
        barrier.enabled = open;

        animator.SetBool("Grow", open);

        audioPlayer.Play();
    }

    private void Awake()
    {
        barrier.enabled = false;

        animator.SetBool("Grow", false);
    }
}
