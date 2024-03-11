using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderAmountsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sucessfull;
    [SerializeField] private TextMeshProUGUI failed;
    [SerializeField] private TextMeshProUGUI expired;

    [SerializeField] KitchenChaosGameManager gameManager;

    private void Start()
    {
        gameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(object sender, KitchenChaosGameManager.OnGameStateChangedEventArgs e)
    {
        if(e.state == KitchenChaosGameManager.State.GameOver || e.state == KitchenChaosGameManager.State.LevelComplete)
        {
            sucessfull.text = Order.GetSucessfullOrdersAmount().ToString();
            expired.text = Order.GetExpiredOrdersAmount().ToString();
            failed.text = Order.GetFailedOrdersAmount().ToString();
        }
    }

    
}
