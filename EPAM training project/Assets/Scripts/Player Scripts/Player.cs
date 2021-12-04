using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public event Action PlayerDied;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private PlayerLevel level;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PlayerShooting playerShooting;
    [HideInInspector] public Camera cam;

    private Rigidbody _rb;
    public PlayerShooting PlayerShooting => playerShooting;
    public PlayerStats PlayerStats => playerStats;
    public PlayerLevel PlayerLevel => level;
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
        Health.maxHealthPoints = LevelController.Instance.GameData.maxHealth;
        Health.HealthPoints = LevelController.Instance.GameData.currentHealth;
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
