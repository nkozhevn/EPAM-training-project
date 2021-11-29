using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private string levelName = "1";
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject modsButtons;
    [SerializeField] private GameObject loadPlug;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private string gameThemeSoundName;
    [SerializeField] private string menuThemeSoundName;
    [SerializeField] private string clickSoundName;

    [SerializeField] private Button loadButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button easyButton;
    [SerializeField] private Button hardButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        loadButton.onClick.AddListener(LoadButton);
        playButton.onClick.AddListener(PlayButton);
        easyButton.onClick.AddListener(EasyButton);
        hardButton.onClick.AddListener(HardButton);
        settingsButton.onClick.AddListener(SettingsButton);
        exitButton.onClick.AddListener(ExitButton);
    }

    private void Start()
    {
        modsButtons.SetActive(false);
        if(LevelController.Instance.GameData.level != levelName)
        {
            loadPlug.SetActive(false);
        }

        audioManager.Pause(gameThemeSoundName);
        audioManager.Play(menuThemeSoundName);
    }

    public void LoadButton()
    {
        audioManager.Play(clickSoundName);
        SceneManager.LoadScene(LevelController.Instance.GameData.level);
    }

    public void PlayButton()
    {
        audioManager.Play(clickSoundName);
        modsButtons.SetActive(true);
    }

    public void EasyButton()
    {
        audioManager.Play(clickSoundName);
        LevelController.Instance.SetDifficulty(0);
        SceneManager.LoadScene(levelName);
    }

    public void HardButton()
    {
        audioManager.Play(clickSoundName);
        LevelController.Instance.SetDifficulty(1);
        SceneManager.LoadScene(levelName);
    }

    public void SettingsButton()
    {
        audioManager.Play(clickSoundName);
        settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitButton()
    {
        audioManager.Play(clickSoundName);
        Application.Quit();
    }
}
