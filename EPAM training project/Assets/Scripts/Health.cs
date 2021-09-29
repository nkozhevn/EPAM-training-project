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

        //_healthSystem = new HealthSystem(healthPoints);

        /*if(gameObject.CompareTag("Player"))
        {
            healthBar.Setup(_healthSystem);
        }*/
    }

    public void RecieveDamage(int amount)
    {
        HealthPoints -= amount;
    }

    /*public void DamageEffect(int x)
    {
        _healthSystem.Damage(x);
        if(_healthSystem.GetHealth() == 0)
        {
            if(gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }
            else if(gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }
    }*/
}
