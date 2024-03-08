using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerOpeningAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BaseCounter containerCounter;
    [SerializeField] Player player;

    private void Start()
    {
        player.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter == containerCounter)
        {
            animator.SetBool("Selected", true);
        }
        else
        {
            animator.SetBool("Selected", false);
        }
    }

   
  }
    


    