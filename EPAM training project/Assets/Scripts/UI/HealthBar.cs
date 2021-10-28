using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image barImage;

    private void Awake()
    {
        Player.Instance.Health.HealthChanged += OnHealthChanged;
    }

    private void OnDestroy() 
    {
        Player.Instance.Health.HealthChanged -= OnHealthChanged;
    }

    public void OnHealthChanged()
    {
        barImage.fillAmount = Player.Instance.Health.HealthPercent;
    }
}
