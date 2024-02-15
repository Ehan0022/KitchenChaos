using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerOpeningAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject containerCounter;

    private void Update()
    {
        if(Player.selectedCounter!=null)
        {
            if (Player.selectedCounter.transform == containerCounter.transform)
            {
                animator.SetBool("Selected", true);
            }
            else
            {
                animator.SetBool("Selected", false);
            }
        } 
        else
        {
            animator.SetBool("Selected", false);
        }
    }
}
