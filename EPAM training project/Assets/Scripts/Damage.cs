using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private Animation _animation;
    [SerializeField] private int healthPoints = 3;
    private int _hitCount;

    private void Awake()
    {
        _hitCount = 0;
        _animation = transform.GetComponent<Animation>();
    }

    public void DamageEffect(int x)
    {
        _hitCount = _hitCount + x;
        if(_hitCount < healthPoints)
        {
            //_animation.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
