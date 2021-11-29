using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLevel : MonoBehaviour
{
    public event Action LevelPointsChanged;
    [SerializeField] private PlayerHealth health;

    private int _level = 0;
    private int _levelPoints;

    public int LevelPoints
    {
        get => _levelPoints;
        set
        {
            _levelPoints = value;
            LevelPointsChanged?.Invoke();
        }
    }
    public int Level => _level;

    public float LevelPointsPercent() => (float)LevelPoints / LevelController.Instance.Player.PlayerStats.MaxLevelPoints;
    public string StringLevelNumber() => _level.ToString();

    private void Start()
    {
        _level = LevelController.Instance.GameData.playerLevel;
        health.HealthUpgrade((_level - 1) * 5);
        GainLevelPoints(LevelController.Instance.GameData.playerLevelPoints);
    }

    public void GainLevelPoints(int amount)
    {
        LevelPoints += amount;
        if((LevelPoints) >= LevelController.Instance.Player.PlayerStats.MaxLevelPoints)
        {
            for(int i = 0; i < LevelPoints / LevelController.Instance.Player.PlayerStats.MaxLevelPoints; i++)
            {
                _level++;
                health.HealthUpgrade(5);
                LevelPoints -= LevelController.Instance.Player.PlayerStats.MaxLevelPoints;
            }
        }
    }
}
