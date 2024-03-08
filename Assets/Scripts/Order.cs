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
}
