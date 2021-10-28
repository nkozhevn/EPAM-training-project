using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health health;
    private Rigidbody _rb;
    
    [SerializeField] private int levelPoints;

    protected Rigidbody Rigidbody => _rb;
    protected Vector3 Direction { get; set; }
    protected Vector3 DirectionNorm { get; set; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        health.HealthChanged += OnHealthChanged;
    }

    private void Update()
    {
        Direction = Player.Instance.GetPosition() - _rb.position;
        DirectionNorm = Direction / Direction.magnitude;
    }

    public void OnHealthChanged()
    {
        if(health.NoHealth)
        {
            Destroy(gameObject);
            Player.Instance.level.GainLevelPoints(levelPoints);
        }
    }
}
