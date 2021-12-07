using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private PauseScreen pauseScreen;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private GameOverScreen finishScreen;
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private AmmoBar ammoUI;
    public AmmoBar AmmoUI => ammoUI;

    private void Start()
    {
        ingameUI.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(LevelController.Instance.gameIsPaused)
            {
                pauseScreen.Resume();
            }
            else
            {
                pauseScreen.Pause();
            }
        }
    }

    public void GameOver()
    {
        gameOverScreen.GameOver();
    }

    public void Finish()
    {
        finishScreen.GameOver();
    }
}
