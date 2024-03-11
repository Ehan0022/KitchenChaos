using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Order : MonoBehaviour
{
    [SerializeField] List<Image> slotList;
    [SerializeField] List<KitchenObjectSO> fixedKitchenObjectSOList;

    [SerializeField] private List<KitchenObjectSO> orderIngredientList;
    [SerializeField] private TextMeshProUGUI typeText;
    [SerializeField] private Animator animator;    
    [SerializeField] public bool slotOccupied = false;

    private static int sucessfullOrders = 0;
    private static int expiredOrders = 0;
    private static int failedOrders = 0;

    public static event EventHandler OnAnyOrderDeliverySuccess;
    public static event EventHandler OnAnyOrderDeliveryFail;




    [SerializeField] SoundManager soundManager;

    public float duration = 20f;
    public float timer = 0f;

    private void Start()
    {
        orderIngredientList = new List<KitchenObjectSO>();
    }

    public void SetOrder(string type, List<KitchenObjectSO> orderIngredientListX)
    {
        orderIngredientList = orderIngredientListX;
        slotOccupied = true;
        typeText.text = type;
        animator.SetBool("OrderIsPresent", true);
        for (int i = 0; i < orderIngredientList.Count; i++)
        {
            if (fixedKitchenObjectSOList.Contains(orderIngredientList[i]))
            {
                slotList[i].color = new Color(slotList[i].color.r, slotList[i].color.g, slotList[i].color.b, 1);
                slotList[i].sprite = orderIngredientList[i].sprite;
            }
        }
    }

    public void PlayAboutToExpireAnimation()
    {
        animator.SetBool("OrderIsAboutToExpire", true);
    }

    public void CompleteSuccesfullOrder()
    {
        sucessfullOrders++;
        soundManager.DeliveryCounterOnOrderDeliverySuccessSound();
        OnAnyOrderDeliverySuccess?.Invoke(this, EventArgs.Empty);
        timer = 0f;
        orderIngredientList.Clear();
        animator.SetBool("OrderIsPresent", false);
        slotOccupied = false;
        animator.SetBool("OrderIsAboutToExpire", false);

        for (int i = 0; i < 5; i++)
        {
            slotList[i].color = new Color(slotList[i].color.r, slotList[i].color.g, slotList[i].color.b, 0);
        }
    }

    public void CompleteFailedOrder()
    {
        expiredOrders++;
        soundManager.DeliveryCounterOnOrderDeliveryFailSound();
        OnAnyOrderDeliveryFail?.Invoke(this, EventArgs.Empty);
        timer = 0f;
        orderIngredientList.Clear();
        animator.SetBool("OrderIsPresent", false);
        slotOccupied = false;
        animator.SetBool("OrderIsAboutToExpire", false);

        for (int i = 0; i < 5; i++)
        {
          slotList[i].color = new Color(slotList[i].color.r, slotList[i].color.g, slotList[i].color.b, 0);         
        }
    }

    


    public List<KitchenObjectSO> GetOrderIngredientList()
    {
        return orderIngredientList;
    }

    public static void IncrementFailedOrders()
    {
        failedOrders++;
    }

    public static int GetSucessfullOrdersAmount()
    {
        return sucessfullOrders;
    }

    public static int GetExpiredOrdersAmount()
    {
        return expiredOrders;
    }
    public static int GetFailedOrdersAmount()
    {
        return failedOrders;
    }
}
