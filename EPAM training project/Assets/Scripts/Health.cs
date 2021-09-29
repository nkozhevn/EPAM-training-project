using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int healthPoints = 10;
    private HealthSystem _healthSystem;
    [SerializeField] private HealthBar healthBar;

    private void Awake()
    {
        _healthSystem = new HealthSystem(healthPoints);

        if(gameObject.CompareTag("Player"))
        {
            healthBar.Setup(_healthSystem);
        }
    }

    public void DamageEffect(int x)
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
    }
}
