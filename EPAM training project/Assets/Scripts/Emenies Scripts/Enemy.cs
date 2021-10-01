using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health health;
    private Rigidbody _rb;
    [SerializeField] public Vector3 direction{ get; set; }
    [SerializeField] public Vector3 directionNorm{ get; set; }
    public Rigidbody Rigidbody() => _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        health.HealthChanged += OnHealthChanged;
    }

    private void Update()
    {
        direction = Player.Instance.GetPosition() - _rb.position;
        directionNorm = direction / direction.magnitude;
    }

    public void OnHealthChanged()
    {
        if(health.NoHealth)
        {
            Destroy(gameObject);
        }
    }
}
