using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatesCounter : BaseCounter
{
    public event EventHandler<OnPlateAmountChangedEventArgs> OnPlateAmountChanged;
    public class OnPlateAmountChangedEventArgs : EventArgs
    {
        public int plateAmount;
    }

    [SerializeField] KitchenObjectSO plateSO;

    List<GameObject> plateVisiuals = new List<GameObject>();


    private void Start()
    {
        for(int i=0; i<4; i++)
        {
            plateVisiuals.Add(new GameObject());
        }
    }


    public override void Interact(Player player)
    {

            if (HasPlatesOnTop() == true)
            {
                //this counter has plates
                if (player.HasKitchenObject())
                {
                    //player is carrying a kitchen object
                    if (player.getKitchenObject().GetKitchenObjectSO().name.Equals("Plate"))
                    {
                        //the player is carrying a plate
                        plateVisiuals.Add(new GameObject());
                        OnPlateAmountChanged?.Invoke(this, new OnPlateAmountChangedEventArgs { plateAmount = plateVisiuals.Count });
                        player.getKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    KitchenObject.SpawnKitchenObject(plateSO, player);
                    plateVisiuals.RemoveAt(plateVisiuals.Count - 1);
                    OnPlateAmountChanged?.Invoke(this, new OnPlateAmountChangedEventArgs { plateAmount = plateVisiuals.Count });
                }
            }
            else
            {
                //this counter is empty
                if (player.HasKitchenObject())
                {
                    //the player has a kitchen object
                    if (player.getKitchenObject().GetKitchenObjectSO().name.Equals("Plate"))
                    {
                        //the player is carrying a plate
                        plateVisiuals.Add(new GameObject());
                        OnPlateAmountChanged?.Invoke(this, new OnPlateAmountChangedEventArgs { plateAmount = plateVisiuals.Count });
                        player.getKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    //player is not carrying a kitchen object
                }
            }
             
    }




    public bool HasPlatesOnTop()
    {
        if(plateVisiuals.Count!=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
