using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour, IDamageable
{
    public event Action HealthChanged;
    [SerializeField] public int maxHealthPoints = 10;
    public bool NoHealth => _healthPoints <= 0;
    private int _healthPoints;
    public int HealthPoints
    {
        get => _healthPoints;
        set
        {
            _healthPoints = value;
            HealthChanged?.Invoke();
        }
    }

    private void Awake()
    {
        HealthPoints = maxHealthPoints;
    }

    public void RecieveDamage(int amount)
    {
        HealthPoints -= amount;
    }

    public void RestoreHealth(int amount)
    {
        HealthPoints += amount;
    }

    public void HealthUpgrade(int amount)
    {
        maxHealthPoints += amount;
        HealthPoints = HealthPoints;
    }

    public float HealthPercent() => (float)HealthPoints / maxHealthPoints;
}
