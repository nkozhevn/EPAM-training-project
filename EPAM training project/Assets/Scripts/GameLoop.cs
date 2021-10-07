using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private GameOverScreen gameOverScreen;

    private void Awake()
    {
        Player.Instance.PlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        gameOverScreen.Setup();
    }

    private void OnDestroy()
    {
        Player.Instance.PlayerDied -= OnPlayerDied;
    }
}
