using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{


    [SerializeField] KitchenObjectSO kitchenObjectSOtomato;
    [SerializeField] KitchenObjectSO kitchenObjectSOcabbage;
    [SerializeField] KitchenObjectSO kitchenObjectSOcheese;


    public override void Interact(Player player)
    {
        if (HasKitchenObject() == true)
        {
            //this counter has a kitchen object on top
            if (player.HasKitchenObject())
            {
                //player is carrying a kitchen object
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
            }
            else
            {
                //player is not carrying a kitchen object
            }
        }
    }


    private const int cheeseMaxSlice = 3;
    private const int cabbageMaxSlice = 5;
    private const int tomatoMaxSlice = 4;
    public override void InteractAlternate(Player player)
    {
        
        if(HasKitchenObject()&&getKitchenObject().GetKitchenObjectSO().sliceable)
        {
            //the kitchen object on top of this counter is sliceable
          if(kitchenObjectOnTop.GetKitchenObjectSO().objectName.Equals("Tomato"))
          {
                kitchenObjectOnTop.IncrementSliceCount();
                if(kitchenObjectOnTop.GetSliceCount()==tomatoMaxSlice)
                {
                    kitchenObjectOnTop.DestroySelf();
                    KitchenObject.SpawnKitchenObject(kitchenObjectSOtomato, this);
                }             
          }

          if (kitchenObjectOnTop.GetKitchenObjectSO().objectName.Equals("Cabbage"))
          {
                kitchenObjectOnTop.IncrementSliceCount();
                if (kitchenObjectOnTop.GetSliceCount() == cabbageMaxSlice)
                {
                    kitchenObjectOnTop.DestroySelf();
                    KitchenObject.SpawnKitchenObject(kitchenObjectSOcabbage, this);
                }
                
          }

          if (kitchenObjectOnTop.GetKitchenObjectSO().objectName.Equals("Cheese"))
          {
                kitchenObjectOnTop.IncrementSliceCount();
                if (kitchenObjectOnTop.GetSliceCount() == cheeseMaxSlice)
               {
                   kitchenObjectOnTop.DestroySelf();
                   KitchenObject.SpawnKitchenObject(kitchenObjectSOcheese, this);
               }
          }
        }      
    }

 




}
