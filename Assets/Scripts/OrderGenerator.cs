using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OrderGenerator : MonoBehaviour
{
    public event EventHandler <OnOrderGeneratedEventArgs> OnOrderGenerated;

    public class OnOrderGeneratedEventArgs : EventArgs
    {
        public List<KitchenObjectSO> orderKitchenObjectSOList;
    }


    private int addCheck = 0;
    [SerializeField] private List<KitchenObjectSO> fixedOrderKitchenObjectSOList;
    //fixed items
    [SerializeField] private KitchenObjectSO bread;
    [SerializeField] private KitchenObjectSO meat;
    

    private float generateOrderTimeMax = 5;
    private float generateOrderTimer = 0;
    System.Random random = new System.Random();

    public List<KitchenObjectSO> GenerateNewOrder()
    {
        List<KitchenObjectSO> orderKitchenObjectSOList = new List<KitchenObjectSO>();      
        for (int i = 0; i < 3; i++)
        {
            addCheck = random.Next(0, 2);
            if (addCheck == 1)
            {
                orderKitchenObjectSOList.Add(fixedOrderKitchenObjectSOList[i]);
            }
        }
        //add the KitcjenObjectSO's that all orders will require
        orderKitchenObjectSOList.Add(bread);
        orderKitchenObjectSOList.Add(meat);
        return orderKitchenObjectSOList;
    }

    private void Update()
    {
        generateOrderTimer += Time.deltaTime;
        if(generateOrderTimer >= generateOrderTimeMax)
        {           
            generateOrderTimeMax = random.Next(5, 10);
            generateOrderTimer = 0;
            OnOrderGenerated?.Invoke(this, new OnOrderGeneratedEventArgs { orderKitchenObjectSOList = GenerateNewOrder() });
        }
    }
}
