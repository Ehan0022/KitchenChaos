using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Order : MonoBehaviour
{
    [SerializeField] List<Image> slotList;
    [SerializeField] List<KitchenObjectSO> fixedKitchenObjectSOList;

    private List<KitchenObjectSO> orderIngredientList;
    [SerializeField] private TextMeshProUGUI typeText;
    [SerializeField] private Animator animator;    
    [SerializeField] private int orderNumber;
    [SerializeField] public bool slotOccupied = false;

   

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

    public List<KitchenObjectSO> GetOrderIngredientList()
    {
        return orderIngredientList;
    }

    public void CompleteOrder()
    {
        orderIngredientList.Clear();
        animator.SetBool("OrderIsPresent", false);
        slotOccupied = false;
    }
}
