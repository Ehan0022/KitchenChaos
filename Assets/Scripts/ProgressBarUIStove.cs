using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUIStove : MonoBehaviour
{
    [SerializeField] Image progress;
    [SerializeField] CookingCounter cookingCounter;
 

    private Vector3 scale;

   


    private void Update()
    {
        HandleBarProgress();
        HandleBarVisibility();
    }

    private void HandleBarVisibility()
    {
        if (cookingCounter.HasKitchenObject() && cookingCounter.getKitchenObject().GetKitchenObjectSO().canBeCookedFurther)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.zero;
        }
    }

    private void HandleBarProgress()
    {
        if (cookingCounter.HasKitchenObject() && cookingCounter.getKitchenObject().GetKitchenObjectSO().canBeCookedFurther)
        {
            progress.fillAmount = cookingCounter.getTimerCount() / 4;
        }
        else
        {
            progress.fillAmount = 0;
        }
    }



}

