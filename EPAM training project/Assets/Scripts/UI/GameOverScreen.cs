using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private string nextLevelName = "2";
    [SerializeField] private string menuSceneName = "Main Menu";

    public void GameOver()
    {
        gameObject.SetActive(true);
        ingameUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(nextLevelName);
        Time.timeScale = 1f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
