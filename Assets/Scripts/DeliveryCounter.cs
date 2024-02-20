using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DeliveryCounter : BaseCounter
{
    [SerializeField] private OrderGenerator orderGenerator;
    [SerializeField] private List<List<KitchenObjectSO>> orderList;

    [SerializeField] private List<KitchenObjectSO> order1;
    [SerializeField] private List<KitchenObjectSO> order2;
    [SerializeField] private List<KitchenObjectSO> order3;

    [SerializeField] private KitchenObjectSO cheese;
    [SerializeField] private KitchenObjectSO cabbage;
    [SerializeField] private KitchenObjectSO tomatoes;

   
    private void Start()
    {
        orderList = new List<List<KitchenObjectSO>>();
        orderGenerator.OnOrderGenerated += OrderGenerator_OnOrderGenerated;
    }


    private void OrderGenerator_OnOrderGenerated(object sender, OrderGenerator.OnOrderGeneratedEventArgs e)
    {
        orderList.Add(e.orderKitchenObjectSOList);
    }

    private void Update()
    {
        Debug.Log("Order list lenght" + orderList.Count);
        if(orderList.Count >= 3)
        {
            order1 = orderList[0];
            order2 = orderList[1];
            order3 = orderList[2];
        }
    }
    public override void Interact(Player player)
    {
        Debug.Log("Interact happens");
        if(player.getKitchenObject() != null)
        {
            //player is carrying a kitchen object
            if(player.getKitchenObject().GetKitchenObjectSO().name.Equals("Plate"))
            {
                //player is carrying a plate
                PlateObject plateObject = player.getKitchenObject() as PlateObject;
                int correpondingIndex = -1;
                for(int i = 0; i<orderList.Count; i++)
                {
                    if(CompareLists(plateObject.GetIngridientsOnThePlate(), orderList[i]))
                    {
                        correpondingIndex = i;
                    }
                }

                if(correpondingIndex == -1)
                {
                    //plate is not an order
                    Debug.Log("Is not an Order");
                }
                else
                {
                    Debug.Log("Order completed");
                    orderList.Remove(orderList[correpondingIndex]);
                    player.getKitchenObject().DestroySelf();
                }
                
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
        else
            return true;
    }



}
