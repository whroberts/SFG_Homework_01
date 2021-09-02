using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasurePickup : CollectibleBase
{
    [SerializeField] int _treasureValue = 1;

    protected override void Collect(Player player)
    {
        //calls the CollectTreasure and adds the value of the treasure
        player.CollectTreasure(_treasureValue);
    }
}
