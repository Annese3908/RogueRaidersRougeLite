using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : InteractableObject
{
    [SerializeField] protected SpriteRenderer waterSprite;
    [SerializeField] protected Player player;

    protected virtual bool CanBeBought()
    {
        return player.FullBucketCount() > 0;
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
        waterSprite.enabled = isInteractable & CanBeBought();

        base.Update();
    }
}
