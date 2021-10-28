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

    private bool _isInvulnerable;

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

    public void ReceiveDamage(int amount)
    {
        if (_isInvulnerable)
            return;

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

    public void ToggleInvulnerability(bool isOn)
    {
        _isInvulnerable = isOn;
    }

    public float HealthPercent() => (float)HealthPoints / maxHealthPoints;
}
