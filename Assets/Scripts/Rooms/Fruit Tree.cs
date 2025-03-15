using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seeds;

public class FruitTree : InteractableObject
{
    [SerializeField]
    private SpriteRenderer treeSprite;
    [SerializeField]
    private RoomManager room;
    [SerializeField]
    private SeedInventory seedPackets;
    [SerializeField]
    private FruitTreeData data;

    public override void Interact()
    {
        if (isInteractable)
        {
            seedPackets.CollectSeeds(data.Fruit);
            room.UnlockRoom();
        }
    }

    public override void Update()
    {
        isInteractable = room.IsReadyToUnlock();

        base.Update();
    }

    public void Awake()
    {
        treeSprite.sprite = data.PlantSprite;
    }
}
