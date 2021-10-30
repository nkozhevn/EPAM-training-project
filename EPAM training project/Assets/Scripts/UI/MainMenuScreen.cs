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

    private void Start()
    {
        modsButtons.SetActive(false);
        //if(PlayerPrefs.GetString("Level") != levelName)
        if(GameLoop.Instance.GameData.level != levelName)
        {
            loadPlug.SetActive(false);
        }
    }

    public void LoadButton()
    {
        //SceneManager.LoadScene(PlayerPrefs.GetString("Level"));
        SceneManager.LoadScene(GameLoop.Instance.GameData.level);
    }

    public void PlayButton()
    {
        modsButtons.SetActive(true);
    }

    public void EasyButton()
    {
        GameLoop.Instance.SetDifficulty(0);
        SceneManager.LoadScene(levelName);
    }

    public void HardButton()
    {
        GameLoop.Instance.SetDifficulty(1);
        SceneManager.LoadScene(levelName);
    }

    public void SettingsButton()
    {
        settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
