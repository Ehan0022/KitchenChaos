using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DeliveryCounter : BaseCounter
{
    [SerializeField] private OrderGenerator orderGenerator;

    [SerializeField] private List<Order> orderList;


    [SerializeField] private KitchenObjectSO cheese;
    [SerializeField] private KitchenObjectSO cabbage;
    [SerializeField] private KitchenObjectSO tomatoes;
    [SerializeField] private KitchenObjectSO bread;
    [SerializeField] private KitchenObjectSO meat;

    public event EventHandler OnPlateAmountChangedY;

    public override void Interact(Player player)
    {
        Debug.Log("Interact happens");
        if(player.getKitchenObject() != null)
        {
            //player is carrying a kitchen object
            if(player.getKitchenObject().GetKitchenObjectSO().name.Equals("Plate"))
            {
                Debug.Log("Player is carrying a plate");
                //player is carrying a plate
                PlateObject plateObject = player.getKitchenObject() as PlateObject;

                for (int i = 0; i < orderList.Count; i++)
                {
                    if (CompareLists(plateObject.GetIngridientsOnThePlate(), orderList[i].GetOrderIngredientList()))
                    {
                        Debug.Log("Players plate matched with order");
                        //players plate matches with the order
                        orderList[i].CompleteOrder();
                        plateObject.DestroySelf();
                        OnPlateAmountChangedY?.Invoke(this, EventArgs.Empty);
                        break;
                    }
                }
                //players plate does not match
                
            }
        }
    }

    private bool CompareLists(List<KitchenObjectSO> list1, List<KitchenObjectSO> list2)
    {
        if (list1.Count != list2.Count)
            return false;
        if ((list1.Contains(cheese) && !list2.Contains(cheese)) || (!list1.Contains(cheese) && list2.Contains(cheese)))
            return false;
        else if ((list1.Contains(cabbage) && !list2.Contains(cabbage)) || (!list1.Contains(cabbage) && list2.Contains(cabbage)))
            return false;
        else if ((list1.Contains(tomatoes) && !list2.Contains(tomatoes)) || (!list1.Contains(tomatoes) && list2.Contains(tomatoes)))
            return false;
        else if ((list1.Contains(bread) && !list2.Contains(bread)) || (!list1.Contains(bread) && list2.Contains(bread)))
            return false;
        else if ((list1.Contains(meat) && !list2.Contains(meat)) || (!list1.Contains(meat) && list2.Contains(meat)))
            return false;
        else
            return true;
    }



}
