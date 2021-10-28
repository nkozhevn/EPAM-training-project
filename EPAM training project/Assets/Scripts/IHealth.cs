using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    void RecieveDamage(int amount);
    void RestoreHealth(int amount);
}
