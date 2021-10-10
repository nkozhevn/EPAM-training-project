using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameLoop gameLoop;
    [SerializeField] private string menuSceneName = "Main Menu";

    public void Pause()
    {
        gameObject.SetActive(true);
        ingameUI.SetActive(false);
        Time.timeScale = 0f;
        gameLoop.gameIsPaused = true;
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        ingameUI.SetActive(true);
        Time.timeScale = 1f;
        gameLoop.gameIsPaused = false;
    }

    public void ResumeButton()
    {
        Resume();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void SettingsButton()
    {
        settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}
