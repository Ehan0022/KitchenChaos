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


    private void Update()
    {       
        if(orderList[0].slotOccupied)
        {
            orderList[0].timer += Time.deltaTime;

            if (orderList[0].duration - orderList[0].timer < 5f)
                orderList[0].PlayAboutToExpireAnimation();

            if (orderList[0].timer > orderList[0].duration)
                orderList[0].CompleteFailedOrder();
        }

        if (orderList[1].slotOccupied)
        {
            orderList[1].timer += Time.deltaTime;

            if (orderList[1].duration - orderList[1].timer < 5f)
                orderList[1].PlayAboutToExpireAnimation();

            if (orderList[1].timer > orderList[1].duration)
                orderList[1].CompleteFailedOrder();
        }

        if (orderList[2].slotOccupied)
        {
            orderList[2].timer += Time.deltaTime;

            if (orderList[2].duration - orderList[2].timer < 5f)
                orderList[2].PlayAboutToExpireAnimation();

            if (orderList[2].timer > orderList[2].duration)
                orderList[2].CompleteFailedOrder();
        }

        if (orderList[3].slotOccupied)
        {
            orderList[3].timer += Time.deltaTime;

            if (orderList[3].duration - orderList[3].timer < 5f)
                orderList[3].PlayAboutToExpireAnimation();

            if (orderList[3].timer > orderList[3].duration)
                orderList[3].CompleteFailedOrder();
        }

        if (orderList[4].slotOccupied)
        {
            orderList[4].timer += Time.deltaTime;

            if (orderList[4].duration - orderList[4].timer < 5f)
                orderList[4].PlayAboutToExpireAnimation();

            if (orderList[4].timer > orderList[4].duration)
                orderList[4].CompleteFailedOrder();
        }
    }



}
