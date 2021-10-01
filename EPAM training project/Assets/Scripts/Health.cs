using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour, IDamageable
{
    public event Action HealthChanged;
    [SerializeField] public int maxHealthPoints = 10;
    public bool NoHealth => _healthPoints < 0;
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
        _healthPoints = maxHealthPoints;
    }

    public void RecieveDamage(int amount)
    {
        HealthPoints -= amount;
    }
}
