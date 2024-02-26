using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] List<Order> orderList;

    [SerializeField] OrderGenerator orderGenerator;

    private void Start()
    {
        orderGenerator.OnOrderGenerated += OrderGenerator_OnOrderGenerated; ;
    }

    private void OrderGenerator_OnOrderGenerated(object sender, OrderGenerator.OnOrderGeneratedEventArgs e)
    {
        for(int i=0; i<5; i++)
        {
            if (!orderList[i].slotOccupied)
            {
                orderList[i].SetOrder(e.type, e.orderKitchenObjectSOList);
                break;
            }
        }
    }



}
