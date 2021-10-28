using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Health health;
    protected Rigidbody _rb;
    [SerializeField] protected int levelPoints;
    protected Vector3 Direction { get; set; }
    protected Vector3 DirectionNorm { get; set; }
    protected Rigidbody Rigidbody => _rb;

    /*private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        health.HealthChanged += OnHealthChanged;
    }

    private void Update()
    {
        Direction = Player.Instance.GetPosition - _rb.position;
        DirectionNorm = Direction / Direction.magnitude;
    }

    public void OnHealthChanged()
    {
        if(health.NoHealth)
        {
            Destroy(gameObject);
            Player.Instance.level.GainLevelPoints(levelPoints);
        }
    }*/
}
