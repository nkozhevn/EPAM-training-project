using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance{ get; private set; }
    [SerializeField] private Health health;
    [SerializeField] public bool isActive;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float turnSpeed = 10f;
    private Rigidbody _rb;
    [SerializeField] public Camera cam;

    private void Awake()
    {
        Instance = this;
        health.HealthChanged += OnHealthChanged;
        _rb = GetComponent<Rigidbody>();
        isActive = true;
    }
    
    public Vector3 GetPosition() => transform.position;
    public Rigidbody Rigidbody() => _rb;

    public void OnHealthChanged()
    {
        if(health.NoHealth)
        {
            gameObject.SetActive(false);
            isActive = false;
        }
    }
}
