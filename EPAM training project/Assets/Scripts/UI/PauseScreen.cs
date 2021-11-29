using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private string menuSceneName = "Main Menu";
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private string gameThemeSoundName;
    [SerializeField] private string menuThemeSoundName;
    [SerializeField] private string clickSoundName;

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button menuButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(ResumeButton);
        restartButton.onClick.AddListener(RestartButton);
        settingsButton.onClick.AddListener(SettingsButton);
        menuButton.onClick.AddListener(MenuButton);
    }

    public void Pause()
    {
        gameObject.SetActive(true);
        ingameUI.SetActive(false);
        Time.timeScale = 0f;
        LevelController.Instance.gameIsPaused = true;
        audioManager.Pause(gameThemeSoundName);
        audioManager.Play(menuThemeSoundName);
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        ingameUI.SetActive(true);
        Time.timeScale = 1f;
        LevelController.Instance.gameIsPaused = false;
        audioManager.Pause(menuThemeSoundName);
        audioManager.Play(gameThemeSoundName);
    }

    public void ResumeButton()
    {
        audioManager.Play(clickSoundName);
        Resume();
    }

    public void RestartButton()
    {
        audioManager.Play(clickSoundName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void SettingsButton()
    {
        audioManager.Play(clickSoundName);
        settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void MenuButton()
    {
        audioManager.Play(clickSoundName);
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}
