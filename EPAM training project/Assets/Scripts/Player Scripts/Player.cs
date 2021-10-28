using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static Player Instance{ get; private set; }
    public event Action PlayerDied;
    [SerializeField] private PlayerHealth health;
    [SerializeField] public Level level;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float turnSpeed = 10f;
    private Rigidbody _rb;
    [SerializeField] public Camera cam;
    public PlayerHealth Health => health;

    private void Awake()
    {
        Instance = this;

        health.HealthChanged += OnHealthChanged;

        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        health.maxHealthPoints = PlayerPrefs.GetInt("MaxHealth", health.maxHealthPoints);
        health.HealthPoints = PlayerPrefs.GetInt("CurrentHealth", health.maxHealthPoints);
    }
    
    public Vector3 GetPosition => transform.position;
    public Rigidbody Rigidbody => _rb;

    public void OnHealthChanged()
    {
        if(health.NoHealth)
        {
            PlayerDied?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
