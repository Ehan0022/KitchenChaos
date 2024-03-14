using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KitchenChaosGameManager : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    public enum State
    {
        WaitingForStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
        LevelComplete,
    }

    private State state;
    private float waitingToStartTimer = 1f;
    [SerializeField]  private float countdownToStartTimer = 3f;
    private float gamePlayingTimer = 1500f;
    private bool isGamePaused = false;

    // Update is called once per frame

    public event EventHandler<OnGameStateChangedEventArgs> OnGameStateChanged;

    public class OnGameStateChangedEventArgs : EventArgs
    {
        public State state;
        public float waitingToStartTimer;
        public float countdownToStartTimer;
    }

    private void Awake()
    {
        state = State.WaitingForStart;
    }

    [SerializeField] GameProgressBarUI gameProgress;
    private void Start()
    {
        gameProgress.OnLevelEnd += GameProgress_OnLevelEnd;
        gameInput.OnPauseAction += GameInput_OnPauseAction;
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        TogglePause();
    }



    private void GameProgress_OnLevelEnd(object sender, GameProgressBarUI.OnLevelEndEventArgs e)
    {
        if(e.levelEndStatus.Equals("Fail"))
        {
            state = State.GameOver;
            OnGameStateChanged?.Invoke(this, new OnGameStateChangedEventArgs { state = state, waitingToStartTimer = waitingToStartTimer, countdownToStartTimer = countdownToStartTimer });
        }
        else if(e.levelEndStatus.Equals("Success"))
        {
            state = State.LevelComplete;
            OnGameStateChanged?.Invoke(this, new OnGameStateChangedEventArgs { state = state, waitingToStartTimer = waitingToStartTimer, countdownToStartTimer = countdownToStartTimer });
        }
    }

    void Update()
    {
        switch (state)
        {
            case State.WaitingForStart:
                waitingToStartTimer -= Time.deltaTime;
                if(waitingToStartTimer <= 0f)
                {
                    state = State.CountdownToStart;
                    OnGameStateChanged?.Invoke(this, new OnGameStateChangedEventArgs { state = state, waitingToStartTimer = waitingToStartTimer, countdownToStartTimer = countdownToStartTimer});
                }
                break;

            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer <= 0f)
                {
                    state = State.GamePlaying;
                    OnGameStateChanged?.Invoke(this, new OnGameStateChangedEventArgs { state = state, waitingToStartTimer = waitingToStartTimer, countdownToStartTimer = countdownToStartTimer  });
                }
                break;          
        } 
        

    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public float GetCountDownToStartTimer()
    {
        return countdownToStartTimer;
    }

    [SerializeField] GameObject pauseMenu;
    public void TogglePause()
    {
        if(isGamePaused == false)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            isGamePaused = true;
        }
        else if(isGamePaused == true)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isGamePaused = false;
        }
    }

       
}
