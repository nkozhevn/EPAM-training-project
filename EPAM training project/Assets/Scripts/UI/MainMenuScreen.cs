using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Start()
    {
        modsButtons.SetActive(false);
        //if(PlayerPrefs.GetString("Level") != levelName)
        if(GameLoop.Instance.GameData.level != levelName)
        {
            loadPlug.SetActive(false);
        }

        audioManager.Pause(gameThemeSoundName);
        audioManager.Play(menuThemeSoundName);
    }

    public void LoadButton()
    {
        //SceneManager.LoadScene(PlayerPrefs.GetString("Level"));
        audioManager.Play(clickSoundName);
        SceneManager.LoadScene(GameLoop.Instance.GameData.level);
    }

    public void PlayButton()
    {
        audioManager.Play(clickSoundName);
        modsButtons.SetActive(true);
    }

    public void EasyButton()
    {
        audioManager.Play(clickSoundName);
        GameLoop.Instance.SetDifficulty(0);
        SceneManager.LoadScene(levelName);
    }

    public void HardButton()
    {
        audioManager.Play(clickSoundName);
        GameLoop.Instance.SetDifficulty(1);
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
