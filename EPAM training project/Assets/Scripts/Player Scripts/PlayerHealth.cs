using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private void Awake()
    {
        HealthPoints = maxHealthPoints;
    }

    public void HealthUpgrade(int amount)
    {
        maxHealthPoints += amount;
        HealthPoints = HealthPoints;
    }
}
