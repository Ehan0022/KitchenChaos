using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    [SerializeField] PlatesCounter platesCounter;

    public override void Interact(Player player)
    {
        if(player.HasKitchenObject())
        {
            player.getKitchenObject().DestroySelf();
        }
    }
}
