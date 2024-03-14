using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private GameObject loadingScreen;

    private void Awake()
    {
        startButton.onClick.AddListener(() => 
        {
            loadingScreen.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        );

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        }
        );

        Time.timeScale = 1f;
    }

}
