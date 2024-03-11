using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;


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
    public event EventHandler OnOrderDeliveryFailDeliveryCounter;

    private List<Order> matchingOrders;
    private List<float> timeValues = new List<float>();
    private void Start()
    {
        matchingOrders = new List<Order>();
    }


    public override void Interact(Player player)
    {
        if (player.getKitchenObject() != null)
        {
            //player is carrying a kitchen object
            if (player.getKitchenObject().GetKitchenObjectSO().name.Equals("Plate"))
            {
                //player is carrying a plate
                PlateObject plateObject = player.getKitchenObject() as PlateObject;

                if(plateObject.GetIngridientsOnThePlate().Count == 0)
                {
                    plateObject.DestroySelf();
                    ResetTimerPriorityLogicValues();
                    OnPlateAmountChangedY?.Invoke(this, EventArgs.Empty);
                    OnOrderDeliveryFailDeliveryCounter?.Invoke(this, EventArgs.Empty);
                    Order.IncrementFailedOrders();
                    return;
                }
                   

                for (int i = 0; i < orderList.Count; i++)
                {
                    if (CompareLists(plateObject.GetIngridientsOnThePlate(), orderList[i].GetOrderIngredientList()))
                    {
                        //players plate matches with the order
                        matchingOrders.Add(orderList[i]);
                    }
                }

                for (int i = 0; i < matchingOrders.Count; i++)
                {
                    timeValues.Add(matchingOrders[i].timer);
                }

                int correctIndex = timeValues.IndexOf(timeValues.Max());

                matchingOrders[correctIndex].CompleteSuccesfullOrder();
                plateObject.DestroySelf();
                ResetTimerPriorityLogicValues();
                OnPlateAmountChangedY?.Invoke(this, EventArgs.Empty);                
                return;

                //if code executes after this line, it means the player provided a wrong plate
                plateObject.DestroySelf();
                ResetTimerPriorityLogicValues();
                OnPlateAmountChangedY?.Invoke(this, EventArgs.Empty);
                OnOrderDeliveryFailDeliveryCounter?.Invoke(this, EventArgs.Empty);
                Order.IncrementFailedOrders();
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

    public void ResetTimerPriorityLogicValues()
    {
        timeValues.Clear();
        matchingOrders.Clear();
    }
}
