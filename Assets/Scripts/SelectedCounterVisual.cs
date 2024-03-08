using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] GameObject selectedCounterVisiual;
    [SerializeField] BaseCounter baseCounter;
    [SerializeField] Player player;

    private void Start()
    {
        player.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if(baseCounter == e.selectedCounter)
        {
            selectedCounterVisiual.SetActive(true);
        }
        else
        {
            selectedCounterVisiual.SetActive(false);
        }
    }
}
