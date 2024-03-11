using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_LevelCompleteUI : MonoBehaviour
{
    [SerializeField] GameObject[] gameOver;
    [SerializeField] GameObject[] levelCompleted;


    [SerializeField] KitchenChaosGameManager gameManager;
    private void Start()
    {
        gameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(object sender, KitchenChaosGameManager.OnGameStateChangedEventArgs e)
    {
        if(e.state == KitchenChaosGameManager.State.GameOver)
        {
            for(int i = 0; i<gameOver.Length; i++)
            {
                gameOver[i].SetActive(true);
            }
        }
        else if(e.state == KitchenChaosGameManager.State.LevelComplete)
        {
            for (int i = 0; i < levelCompleted.Length; i++)
            {
                levelCompleted[i].SetActive(true);
            }
        }
    }
}
