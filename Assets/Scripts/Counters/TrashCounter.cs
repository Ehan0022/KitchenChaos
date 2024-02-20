using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrashCounter : BaseCounter
{
    [SerializeField] PlatesCounter platesCounter;
    public event EventHandler OnPlateAmountChangedX;

    
    public override void Interact(Player player)
    {
        if(player.HasKitchenObject())
        {
            if(player.getKitchenObject().GetKitchenObjectSO().name.Equals("Plate"))
            {
                OnPlateAmountChangedX?.Invoke(this, EventArgs.Empty);
                Debug.Log("The player destroyed a plate object");
            }
            player.getKitchenObject().DestroySelf();
        }
    }
}
