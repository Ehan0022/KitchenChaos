using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameProgressBarUI : MonoBehaviour
{

    [SerializeField] private Image progress;
    private const float maxfillAmount = 100;
    [SerializeField] private float currentFillAmount = 15f;
    [SerializeField] DeliveryCounter deliveryCounter;

    public event EventHandler <OnLevelEndEventArgs> OnLevelEnd;

    public class OnLevelEndEventArgs : EventArgs
    {
        public string levelEndStatus;
    }

    private void Awake()
    {
        progress.fillAmount = ReturnFillAmount();
    }

    void Start()
    {       
        Order.OnAnyOrderDeliverySuccess += Order_OnAnyOrderDeliverySuccess;
        Order.OnAnyOrderDeliveryFail += Order_OnAnyOrderDeliveryFail;
        deliveryCounter.OnOrderDeliveryFailDeliveryCounter += DeliveryCounter_OnOrderDeliveryFailDeliveryCounter;
    }

    private void DeliveryCounter_OnOrderDeliveryFailDeliveryCounter(object sender, System.EventArgs e)
    {
        if (currentFillAmount > 0)
        {
            currentFillAmount -= 10;
            if (currentFillAmount < 0)
                currentFillAmount = 0;
            progress.fillAmount = ReturnFillAmount();
        }

        if (currentFillAmount <= 0f)
        {
            OnLevelEnd?.Invoke(this, new OnLevelEndEventArgs {levelEndStatus = "Fail"});
        }
    }

    private void Order_OnAnyOrderDeliveryFail(object sender, System.EventArgs e)
    {        
        if(currentFillAmount > 0)
        {
            currentFillAmount -= 10;
            if (currentFillAmount < 0)
                currentFillAmount = 0;
            progress.fillAmount = ReturnFillAmount();
        }
        if (currentFillAmount <= 0f)
        {
            OnLevelEnd?.Invoke(this, new OnLevelEndEventArgs { levelEndStatus = "Fail" });
        }
    }

    Order order;
    private void Order_OnAnyOrderDeliverySuccess(object sender, System.EventArgs e)
    {
        if (sender != null)
        {
            order = sender as Order;
        }
        currentFillAmount += (float)order.GetOrderIngredientList().Count * 10f;
        progress.fillAmount = ReturnFillAmount();

        if (ReturnFillAmount() >= 1f)
        {
            OnLevelEnd?.Invoke(this, new OnLevelEndEventArgs { levelEndStatus = "Success" });
        }
    }

    private float ReturnFillAmount()
    {
        return currentFillAmount / maxfillAmount;       
    }



}
