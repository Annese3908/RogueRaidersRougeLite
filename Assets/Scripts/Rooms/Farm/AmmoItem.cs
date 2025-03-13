using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : ShopItem
{
    protected override bool CanBeBought()
    {
        //cannot buy item if at full ammo

        if (player.AtFullAmmo())
            return false;
        return base.CanBeBought();
    }

    protected override void BuyItem()
    {
        //refill ammo when bought

        player.RefillAmmo();
        base.BuyItem();
    }
}