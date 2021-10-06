using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private Health health;

    private void Awake()
    {
        health.HealthChanged += OnHealthChanged;
    }

    private void OnDestroy() {
        health.HealthChanged -= OnHealthChanged;
    }

    public void OnHealthChanged()
    {
        barImage.fillAmount = health.HealthPercent();
    }
}
