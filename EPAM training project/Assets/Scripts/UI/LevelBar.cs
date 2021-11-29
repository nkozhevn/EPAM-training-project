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
        LevelController.Instance.Player.PlayerLevel.LevelPointsChanged += OnLevelPointsChanged;
        OnLevelPointsChanged();
        playerLevelNumber.text = LevelController.Instance.Player.PlayerLevel.StringLevelNumber();
    }

    private void OnDestroy() 
    {
        LevelController.Instance.Player.PlayerLevel.LevelPointsChanged -= OnLevelPointsChanged;
    }

    public void OnLevelPointsChanged()
    {
        barImage.fillAmount = LevelController.Instance.Player.PlayerLevel.LevelPointsPercent();
        playerLevelNumber.text = LevelController.Instance.Player.PlayerLevel.StringLevelNumber();
    }
}
