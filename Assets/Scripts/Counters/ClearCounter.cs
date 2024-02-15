using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter 
{
    [SerializeField] KitchenObjectSO kitchenObject;
    [SerializeField] Transform counterTopPoint;


    public override void Interact(Player player)
    {
        if(HasKitchenObject()==true)
        {
            //this counter has a kitchen object on top
            if(player.HasKitchenObject())
            {
                //player is carrying a kitchen object
                if(player.getKitchenObject() is PlateObject)
                {
                    //the player is carrying a plate
                    PlateObject plateObject = player.getKitchenObject() as PlateObject;
                   if( plateObject.TryAddIngredient(getKitchenObject().GetKitchenObjectSO()))
                    {
                        getKitchenObject().DestroySelf();
                    }                   
                }
                else
                {
                    //the player is not carrying a plate
                    if(kitchenObjectOnTop is PlateObject)
                    {
                        //the counter has a plate
                        PlateObject plateObject = getKitchenObject() as PlateObject;
                        if (plateObject.TryAddIngredient(player.getKitchenObject().GetKitchenObjectSO()))
                        {
                            player.getKitchenObject().DestroySelf();
                        }
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
            if(player.HasKitchenObject())
            {
                //player is carrying a kitchen object
                player.getKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //player is not carrying a kitchen object
            }
        }



    }

   


}
