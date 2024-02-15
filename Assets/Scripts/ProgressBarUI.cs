using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image progress;
    [SerializeField] private BaseCounter baseCounter;

    private float fillAmount = 0;

    private void Update()
    {
        HandleProgressBarForCuttingCounter();
        HandleBarVisibility();
    }

    private void HandleProgressBarForCuttingCounter()
    {
        if (baseCounter.HasKitchenObject())
        {
            progress.fillAmount = (float)baseCounter.getKitchenObject().GetSliceCount() / baseCounter.getKitchenObject().GetKitchenObjectSO().maxSlices;
        }
        else
        {
            progress.fillAmount = 0f;
        }
    }

    private void HandleBarVisibility()
    {
        if (baseCounter.HasKitchenObject() && baseCounter.getKitchenObject().GetKitchenObjectSO().sliceable)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.zero;
        }
    }





}

   