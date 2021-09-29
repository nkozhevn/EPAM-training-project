using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] public event EventHandler onHealthChanged;
    private int _health;
    private int _healthMax;

    public HealthSystem(int healthMax)
    {
        this._healthMax = healthMax;
        _health = healthMax;
    }

    public int GetHealth()
    {
        return _health;
    }

    public float GetHealthPercent()
    {
        return (float)_health / _healthMax;
    }

    public void Damage(int damageAmount)
    {
        _health -= damageAmount;
        if(_health < 0)
        {
            _health = 0;
        }
        if(onHealthChanged != null)
        {
            onHealthChanged(this, EventArgs.Empty);
        }
    }
}
