using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private string levelName = "01";
    [SerializeField] private GameObject settingsMenu;

    public void PlayButton()
    {
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
