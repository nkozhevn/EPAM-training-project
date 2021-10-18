using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private Text playerLevelNumber;
    [SerializeField] private Level level;

    private void Start()
    {
        level.LevelPointsChanged += OnLevelPointsChanged;
        OnLevelPointsChanged();
        playerLevelNumber.text = level.StringLevelNumber();
    }

    private void OnDestroy() {
        level.LevelPointsChanged -= OnLevelPointsChanged;
    }

    public void OnLevelPointsChanged()
    {
        barImage.fillAmount = level.LevelPointsPercent();
        playerLevelNumber.text = level.StringLevelNumber();
    }
}
