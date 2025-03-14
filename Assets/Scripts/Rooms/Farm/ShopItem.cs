using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : InteractableObject
{
    [SerializeField] protected SpriteRenderer waterSprite;
    [SerializeField] protected PlayerStats player;

    protected virtual bool CanBeBought()
    {
        return player.FilledBuckets() > 0;
    }

    protected virtual void BuyItem()
    {
        player.SpendBucket();
    }
    public override void Interact()
    {
        if (CanBeBought())
            BuyItem();
    }
    public override void Update()
    {
        base.Update();

        isInteractable = CanBeBought();
        waterSprite.enabled = isInteractable;
    }
}
