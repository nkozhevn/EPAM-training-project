using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public event Action PlayerDied;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private Level level;
    [SerializeField] public Camera cam;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private PlayerStats playerStats;

    private Rigidbody _rb;
    public PlayerStats PlayerStats => playerStats;
    public Level Level => level;
    public PlayerHealth Health => _health;
    public Inventory Inventory => _inventory;
    public Vector3 GetPosition => transform.position;
    public Rigidbody Rigidbody => _rb;

    private void Awake()
    {
        Health.HealthChanged += OnHealthChanged;

        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Health.maxHealthPoints = GameLoop.Instance.GameData.maxHealth;
        Health.HealthPoints = GameLoop.Instance.GameData.currentHealth;
    }
    
    public void OnHealthChanged()
    {
        if(Health.NoHealth)
        {
            PlayerDied?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
