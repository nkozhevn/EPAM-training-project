using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private GameLoop gameLoop;
    [SerializeField] private string menuSceneName = "Main Menu";
    [SerializeField] private string settingsSceneName = "Settings";

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

    public void SettingsButton()
    {
        SceneManager.LoadScene(settingsSceneName);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
