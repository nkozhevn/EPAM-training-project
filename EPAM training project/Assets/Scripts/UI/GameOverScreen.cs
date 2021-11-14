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
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private string clickSoundName;

    public void GameOver()
    {
        gameObject.SetActive(true);
        ingameUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void NextLevelButton()
    {
        audioManager.Play(clickSoundName);
        SceneManager.LoadScene(nextLevelName);
        Time.timeScale = 1f;
    }

    public void RestartButton()
    {
        audioManager.Play(clickSoundName);
        //SceneManager.LoadScene(PlayerPrefs.GetInt("Level", "1"));
        SceneManager.LoadScene(GameLoop.Instance.GameData.level);
        Time.timeScale = 1f;
    }

    public void MenuButton()
    {
        audioManager.Play(clickSoundName);
        SceneManager.LoadScene(menuSceneName);
    }
}
