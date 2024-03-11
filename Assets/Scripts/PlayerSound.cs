using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] Player player;
    public event EventHandler OnFootStepOccured;
   

    private float soundTimeMax = 0.15f;
    [SerializeField] private float timer = 0.1f;

    private void Update()
    {       
        if(player.IsMoving())
        {
            timer += Time.deltaTime;
            if (timer >= soundTimeMax)
            {
                OnFootStepOccured?.Invoke(this, EventArgs.Empty);
                timer = 0;
            }           
        }
    }
}