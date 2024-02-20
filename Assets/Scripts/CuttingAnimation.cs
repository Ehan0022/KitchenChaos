using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CutCounter cuttingCounter;

    private void Update()
    {
        if (Player.selectedCounter != null && cuttingCounter.HasKitchenObject() && Player.selectedCounter.transform == cuttingCounter.transform)
        {
            //this counter has a kitchen object on top
           if(cuttingCounter.getKitchenObject().GetKitchenObjectSO().sliceable)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    animator.SetTrigger("Cut");
                }
            }
           
        }       
    }
}
