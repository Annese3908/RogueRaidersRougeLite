using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plants;

public class FruitTree : InteractableObject
{
    [SerializeField]
    private SpriteRenderer treeSprite;
    [SerializeField]
    private RoomManager room;
    [SerializeField]
    private SeedInventory seedPackets;
    [SerializeField]
    private PlantData data;
    [SerializeField]
    private AudioSource audioPlayer;

    public override void Interact()
    {
        if (isInteractable)
        {
            seedPackets.CollectSeeds(data.Type);
            room.UnlockRoom();

            audioPlayer.Play();
        }
    }

    public override void Update()
    {
        isInteractable = room.IsReadyToUnlock();

        base.Update();
    }

    public void Awake()
    {
        treeSprite.sprite = data.TreeSprite;
    }
}
