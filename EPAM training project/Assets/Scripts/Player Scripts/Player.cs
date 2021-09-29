using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance{ get; private set; }
    [SerializeField] private Health health;
    [SerializeField] private GameObject model;

    private void Awake()
    {
        Instance = this;
        health.HealthChanged += OnHealthChanged;
    }
    
    public Vector3 GetPosition() => transform.position;

    public void OnHealthChanged()
    {
        if(health.NoHealth)
        {
            model.SetActive(false);
        }
    }
}
