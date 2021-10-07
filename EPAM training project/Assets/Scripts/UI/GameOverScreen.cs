using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private string menuSceneName = "Main Menu";

    public void Setup()
    {
        gameObject.SetActive(true);
        ingameUI.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
