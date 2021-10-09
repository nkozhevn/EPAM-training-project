using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private string levelName = "01";

    public void PlayButton()
    {
        SceneManager.LoadScene(levelName);
    }

    public void SettingsButton()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
