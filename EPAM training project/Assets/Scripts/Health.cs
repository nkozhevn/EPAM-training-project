using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour, IHealth
{
    public event Action HealthChanged;
    [SerializeField] public int maxHealthPoints = 10;
    public bool NoHealth => _healthPoints <= 0;
    protected int _healthPoints;
    protected bool _isInvulnerable;
    public int HealthPoints
    {
        get => _healthPoints;
        set
        {
            _healthPoints = value;
            HealthChanged?.Invoke();
        }
    }

    public float HealthPercent => (float)HealthPoints / maxHealthPoints;

    private void Awake()
    {
        HealthPoints = maxHealthPoints;
    }

    public void RecieveDamage(int amount)
    {
        if (_isInvulnerable)
        {
            return;
        }
        HealthPoints -= amount;
    }

    public void RestoreHealth(int amount)
    {
        HealthPoints += amount;
    }
}
