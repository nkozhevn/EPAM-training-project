using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private string levelName = "01";
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject modsButtons;

    private void Awake()
    {
        modsButtons.SetActive(false);
    }

    public void PlayButton()
    {
        modsButtons.SetActive(true);
    }

    public void EasyButton()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
        PlayerPrefs.SetInt("MaxHealth", 20);
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(levelName);
    }

    public void HardButton()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        PlayerPrefs.SetInt("MaxHealth", 10);
        PlayerPrefs.SetInt("Level", 1);
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
