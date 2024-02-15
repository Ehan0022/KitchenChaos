using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] GameObject selectedCounterVisiual;
    [SerializeField] GameObject Counter;
    
    private void Update()
    {
        if (Player.selectedCounter != null)
        {
            if (Player.selectedCounter.transform == Counter.transform)
            {
                selectedCounterVisiual.SetActive(true);
            }
        }
        else
        {
            selectedCounterVisiual.SetActive(false);
        }
    }
}
