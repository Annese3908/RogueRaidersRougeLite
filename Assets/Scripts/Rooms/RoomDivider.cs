using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDivider : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Collider2D barrier;

    public void Toggle(bool open)
    {
        sprite.enabled = open;
        barrier.enabled = open;
    }

    private void Awake()
    {
        Toggle(false);
    }
}
