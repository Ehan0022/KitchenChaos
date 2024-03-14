using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CookingCounter : BaseCounter
{
    private float timer;

    [SerializeField] KitchenObjectSO meatFried;
    [SerializeField] KitchenObjectSO meatBurned;

    public event EventHandler<OnCookableObjectPlacedEventArgs> OnCookableObjectPlaced;
    public class  OnCookableObjectPlacedEventArgs : EventArgs
    {
        public bool thereIsCookableObjectOnTop;
    }

    


    //CookingCounters Interact fires an event if a cookable object is placed
    public override void Interact(Player player)
    {
        if (HasKitchenObject() == true)
        {
            //this counter has a kitchen object on top
            if (player.HasKitchenObject())
            {
                //player is carrying a kitchen object
                if (player.getKitchenObject() is PlateObject)
                {
                    //the player is carrying a plate
                    PlateObject plateObject = player.getKitchenObject() as PlateObject;
                    if (plateObject.TryAddIngredient(getKitchenObject().GetKitchenObjectSO()))
                    {
                        getKitchenObject().DestroySelf();
                    }

                }
            }
            else
            {
                //player is not carrying a kitchen object
                kitchenObjectOnTop.SetKitchenObjectParent(player);
            }
        }
        else
        {
            //this counter is empty
            if (player.HasKitchenObject())
            {
                //player is carrying a kitchen object
                player.getKitchenObject().SetKitchenObjectParent(this);
                if(kitchenObjectOnTop.GetKitchenObjectSO().canBeCookedFurther)
                {
                    OnCookableObjectPlaced?.Invoke(this, new OnCookableObjectPlacedEventArgs { thereIsCookableObjectOnTop = true }) ;
                }
                
            }
            else
            {
                //player is not carrying a kitchen object
            }
        }


    }


    private float meatCookTime = 4;
    private float meatBurnTime = 4;

    
    private void Update()
    {             
        HandleCooking();     
    }


    static bool eventStopper = true;
    public void HandleCooking()
    {
        if (HasKitchenObject())
        {
            eventStopper = true;
            if (kitchenObjectOnTop.GetKitchenObjectSO().canBeCookedFurther)
            {
                //object on top can get cooked further

                //meat is getting fried
                if (kitchenObjectOnTop.GetKitchenObjectSO().name.Equals("Meat"))
                {
                    timer += Time.deltaTime;
                    if (timer >= meatCookTime)
                    {
                        kitchenObjectOnTop.DestroySelf();
                        KitchenObject.SpawnKitchenObject(meatFried, this);
                        timer = 0;
                    }
                }
                //meat is getting burned
                if (kitchenObjectOnTop.GetKitchenObjectSO().name.Equals("CookedMeat"))
                {
                    timer += Time.deltaTime;
                    if (timer >= meatBurnTime)
                    {
                        kitchenObjectOnTop.DestroySelf();
                        KitchenObject.SpawnKitchenObject(meatBurned, this);                       
                        timer = 0;
                        //meat is burned, no more cookable so fire the event
                        OnCookableObjectPlaced?.Invoke(this, new OnCookableObjectPlacedEventArgs { thereIsCookableObjectOnTop = false });

                    }
                }
            }
        }
        else if(!HasKitchenObject() && eventStopper )
        {
            OnCookableObjectPlaced?.Invoke(this, new OnCookableObjectPlacedEventArgs { thereIsCookableObjectOnTop = false });
            eventStopper = false;
        }
        


    }

    public float getTimerCount()
    {
        return timer;
    }


}
