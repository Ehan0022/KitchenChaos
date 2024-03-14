using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseGameMenuUI : MonoBehaviour
{
    [SerializeField] private Button returnToMenu;
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private GameObject loadingScreen;
    [SerializeField] KitchenChaosGameManager gameManager;


    private void Start()
    {
        returnToMenu.onClick.AddListener(() =>
        {
            loadingScreen.SetActive(true);            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);           
        }
        );

        resumeButton.onClick.AddListener(() =>
        {
            pauseMenu.SetActive(false);
            gameManager.TogglePause();
        }
        );
    }
}
