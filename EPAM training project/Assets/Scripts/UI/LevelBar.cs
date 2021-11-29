using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private Text playerLevelNumber;

    private void Start()
    {
        GameLoop.Instance.Player.Level.LevelPointsChanged += OnLevelPointsChanged;
        OnLevelPointsChanged();
        playerLevelNumber.text = GameLoop.Instance.Player.Level.StringLevelNumber();
    }

    private void OnDestroy() 
    {
        GameLoop.Instance.Player.Level.LevelPointsChanged -= OnLevelPointsChanged;
    }

    public void OnLevelPointsChanged()
    {
        barImage.fillAmount = GameLoop.Instance.Player.Level.LevelPointsPercent();
        playerLevelNumber.text = GameLoop.Instance.Player.Level.StringLevelNumber();
    }
}
