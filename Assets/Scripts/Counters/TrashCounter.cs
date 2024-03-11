using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrashCounter : BaseCounter
{
    [SerializeField] PlatesCounter platesCounter;
    public event EventHandler OnPlateAmountChangedX;
    public event EventHandler OnObjectPutToTrash;


    public override void Interact(Player player)
    {
        if(player.HasKitchenObject())
        {
            if(player.getKitchenObject().GetKitchenObjectSO().name.Equals("Plate"))
            {
                OnPlateAmountChangedX?.Invoke(this, EventArgs.Empty);                
            }
            OnObjectPutToTrash?.Invoke(this, EventArgs.Empty);
            player.getKitchenObject().DestroySelf();
        }
    }
}
