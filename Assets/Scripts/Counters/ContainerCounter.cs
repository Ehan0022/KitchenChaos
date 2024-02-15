using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{

    [SerializeField] KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
        if(player.HasKitchenObject()==false)
        {
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
        }
        
    }

    
}
