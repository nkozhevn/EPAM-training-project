using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level : MonoBehaviour
{
    public event Action LevelPointsChanged;
    private int _level = 0;
    private int _levelPoints;
    [SerializeField] private int maxLevelPoints = 10;
    [SerializeField] private Health health;
    public int LevelPoints
    {
        get => _levelPoints;
        set
        {
            _levelPoints = value;
            LevelPointsChanged?.Invoke();
        }
    }

    private void Awake()
    {
        _level = PlayerPrefs.GetInt("Level");
        health.HealthUpgrade((_level - 1) * 5);
    }

    public void GainLevelPoints(int amount)
    {
        LevelPoints += amount;
        if((LevelPoints) >= maxLevelPoints)
        {
            for(int i = 0; i < LevelPoints / maxLevelPoints; i++)
            {
                _level++;
                PlayerPrefs.SetInt("Level", _level);
                health.HealthUpgrade(5);
                LevelPoints -= maxLevelPoints;
            }
        }
    }

    public float LevelPointsPercent() => (float)LevelPoints / maxLevelPoints;

    public string StringLevelNumber() => _level.ToString();
}
