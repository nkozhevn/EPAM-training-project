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

    private void Awake()
    {
        modsButtons.SetActive(false);
        if(PlayerPrefs.GetString("Level") != levelName)
        {
            loadPlug.SetActive(false);
        }
    }

    public void LoadButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Level"));
    }

    public void PlayButton()
    {
        modsButtons.SetActive(true);
    }

    public void EasyButton()
    {
        PlayerPrefs.SetString("Level", levelName);
        PlayerPrefs.SetInt("Difficulty", 0);
        PlayerPrefs.SetInt("MaxHealth", 20);
        PlayerPrefs.SetInt("CurrentHealth", 20);
        PlayerPrefs.SetInt("PlayerLevel", 0);
        PlayerPrefs.SetInt("PlayerLevelPoints", 0);
        PlayerPrefs.SetInt("Shotgun", 0);
        PlayerPrefs.SetInt("Rifle", 0);
        PlayerPrefs.SetInt("Granade", 0);
        SceneManager.LoadScene(levelName);
    }

    public void HardButton()
    {
        PlayerPrefs.SetString("Level", levelName);
        PlayerPrefs.SetInt("Difficulty", 1);
        PlayerPrefs.SetInt("MaxHealth", 10);
        PlayerPrefs.SetInt("CurrentHealth", 10);
        PlayerPrefs.SetInt("PlayerLevel", 0);
        PlayerPrefs.SetInt("PlayerLevelPoints", 0);
        PlayerPrefs.SetInt("Shotgun", 0);
        PlayerPrefs.SetInt("Rifle", 0);
        PlayerPrefs.SetInt("Granade", 0);
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
