using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int healthPoints = 10;
    private int _hitCount;

    private void Awake()
    {
        _hitCount = 0;
    }

    public void DamageEffect(int x)
    {
        _hitCount = _hitCount + x;
        if(_hitCount >= healthPoints)
        {
            gameObject.SetActive(false);
        }
    }
}
