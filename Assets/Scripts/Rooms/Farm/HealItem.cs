using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : ShopItem
{
    protected override bool CanBeBought()
    {
        //cannot buy item if at full hp

        if (player.hp == player.GetMaxHP())
            return false;
        return base.CanBeBought();
    }

    protected override void BuyItem()
    {
        //full heal when bought

        player.FullHeal();
        base.BuyItem();
    }
}
