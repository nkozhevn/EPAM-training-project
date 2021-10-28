using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public static GameLoop Instance{ get; private set; }
    public bool gameIsPaused = false;
    [SerializeField] private string levelName;
    [SerializeField] private string firstLevelName;
    [SerializeField] private string nextLevelName;
    [SerializeField] private PauseScreen pauseScreen;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private GameOverScreen finishScreen;
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private TriggerObjects finish;
    [SerializeField] private Health playerHealth;
    [SerializeField] private List<UpgradeFinder> upgradeFinders;

    private void Start()
    {
        ingameUI.SetActive(true);

        Time.timeScale = 1f;

        Player.Instance.PlayerDied += OnPlayerDied;
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

        if(finish.IsActivated)
        {
            OnFinish();
        }
    }

    private void OnPlayerDied()
    {
        PlayerPrefs.SetString("Level", firstLevelName);
        gameOverScreen.GameOver();
    }

    private void OnFinish()
    {
        PlayerPrefs.SetString("Level", nextLevelName);
        PlayerPrefs.SetInt("MaxHealth", playerHealth.maxHealthPoints);
        PlayerPrefs.SetInt("CurrentHealth", playerHealth.HealthPoints);
        PlayerPrefs.SetInt("PlayerLevel", Player.Instance.level.PlayerLevel());
        PlayerPrefs.SetInt("PlayerLevelPoints", Player.Instance.level.LevelPoints);
        for(int i = 0; i < upgradeFinders.Count; i++)
        {
            if(upgradeFinders[i].skillGot)
            {
                PlayerPrefs.SetInt(upgradeFinders[i].upgradeName, 1);
            }
        }
        finishScreen.GameOver();
    }

    private void OnDestroy()
    {
        Player.Instance.PlayerDied -= OnPlayerDied;
    }
}
