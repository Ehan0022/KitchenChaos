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
        public string type;
    }


    private int addCheck = 0;
    private int foodCheck = 0;
    [SerializeField] private List<KitchenObjectSO> BurgerOrderKitchenObjectSOList;
    [SerializeField] private List<KitchenObjectSO> SaladOrderKitchenObjectSOList;
    //fixed items
    [SerializeField] private KitchenObjectSO bread;
    [SerializeField] private KitchenObjectSO meat;
    

    private float generateOrderTimeMax = 5;
    private float generateOrderTimer = 0;
    System.Random random = new System.Random();

    public void GenerateNewOrder()
    {
        
        List<KitchenObjectSO> orderKitchenObjectSOList = new List<KitchenObjectSO>();

        foodCheck = random.Next(0, 99);
        //spawning a burger have %65 chance
        if(foodCheck<64)
        {
            for (int i = 0; i < 3; i++)
            {
                addCheck = random.Next(0, 2);
                if (addCheck == 1)
                {
                    orderKitchenObjectSOList.Add(BurgerOrderKitchenObjectSOList[i]);
                }
            }
            //add the KitcjenObjectSO's that all orders will require
            orderKitchenObjectSOList.Add(bread);
            orderKitchenObjectSOList.Add(meat);
            OnOrderGenerated?.Invoke(this, new OnOrderGeneratedEventArgs { orderKitchenObjectSOList = orderKitchenObjectSOList, type = "Burger" });
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                addCheck = random.Next(0, 2);
                if (addCheck == 1 && !orderKitchenObjectSOList.Contains(SaladOrderKitchenObjectSOList[i]))
                {
                    orderKitchenObjectSOList.Add(SaladOrderKitchenObjectSOList[i]);
                }

                if (i == 2 && orderKitchenObjectSOList.Count <= 1)
                {
                    i = 0;
                }
            }
            OnOrderGenerated?.Invoke(this, new OnOrderGeneratedEventArgs { orderKitchenObjectSOList = orderKitchenObjectSOList , type= "Salad"});
        }
        
        
    }

    private void Update()
    {
        generateOrderTimer += Time.deltaTime;
        if(generateOrderTimer >= generateOrderTimeMax)
        {           
            generateOrderTimeMax = random.Next(5, 10);
            generateOrderTimer = 0;
            GenerateNewOrder();
        }
    }


}
