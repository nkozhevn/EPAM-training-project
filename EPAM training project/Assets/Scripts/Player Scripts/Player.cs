using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public event Action PlayerDied;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] public Level level;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float turnSpeed = 10f;
    private Rigidbody _rb;
    [SerializeField] public Camera cam;
    public PlayerHealth Health => _health;

    private void Awake()
    {
        Health.HealthChanged += OnHealthChanged;

        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        /*Health.maxHealthPoints = PlayerPrefs.GetInt("MaxHealth", Health.maxHealthPoints);
        Health.HealthPoints = PlayerPrefs.GetInt("CurrentHealth", Health.maxHealthPoints);*/
        Health.maxHealthPoints = GameLoop.Instance.GameData.maxHealth;
        Health.HealthPoints = GameLoop.Instance.GameData.currentHealth;
    }
    
    public Vector3 GetPosition => transform.position;
    public Rigidbody Rigidbody => _rb;

    public void OnHealthChanged()
    {
        if(Health.NoHealth)
        {
            PlayerDied?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
