using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [HideInInspector] private PlayerHealth _health;

    private void Awake()
    {
        LevelController.Instance.GameInitialized += Initialization;
        LevelController.Instance.LevelEnded += OnLevelEnd;
    }

    private void Initialization()
    {
        _health = LevelController.Instance.Player.Health;
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnLevelEnd() 
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    public void OnHealthChanged()
    {
        barImage.fillAmount = _health.HealthPercent;
    }

    private void OnDestroy()
    {
        LevelController.Instance.GameInitialized -= Initialization;
        LevelController.Instance.LevelEnded -= OnLevelEnd;
    }
}
