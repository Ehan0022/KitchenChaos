using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] KitchenChaosGameManager gameManager;
    [SerializeField] TextMeshProUGUI countdownText;

    [SerializeField] private float maxTimer = 3f;
    
    private bool start = false;

    private void Start()
    {
        gameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(object sender, KitchenChaosGameManager.OnGameStateChangedEventArgs e)
    {
        start = KitchenChaosGameManager.State.CountdownToStart == e.state;       
    }

    private void Update()
    {       
          maxTimer = gameManager.GetCountDownToStartTimer();
          countdownText.text = Mathf.Ceil(maxTimer).ToString();

         if(Mathf.Ceil(maxTimer) == 0f)
        {
            countdownText.enabled = false;
            enabled = false;
        }
    }
}
