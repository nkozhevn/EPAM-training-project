using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public static GameLoop Instance{ get; private set; }
    public bool gameIsPaused = false;
    [SerializeField] private PauseScreen pauseScreen;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private GameOverScreen finishScreen;
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private TriggerObjects finish;

    private void Awake()
    {
        Player.Instance.PlayerDied += OnPlayerDied;

        ingameUI.SetActive(true);

        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                pauseScreen.Resume();
            }
            else
            {
                pauseScreen.Pause();
            }
        }

        if(finish.IsActivated())
        {
            OnFinish();
        }
    }

    private void OnPlayerDied()
    {
        gameOverScreen.GameOver();
    }

    private void OnFinish()
    {
        finishScreen.GameOver();
    }

    private void OnDestroy()
    {
        Player.Instance.PlayerDied -= OnPlayerDied;
    }
}
