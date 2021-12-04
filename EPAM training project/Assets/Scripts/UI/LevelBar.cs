using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private Text playerLevelNumber;
    private PlayerLevel _playerLevel;

    private void Awake()
    {
        LevelController.Instance.GameInitialized += Initialization;
        LevelController.Instance.LevelEnded += OnLevelEnd;
    }

    private void Initialization()
    {
        _playerLevel = LevelController.Instance.Player.PlayerLevel;
        _playerLevel.LevelPointsChanged += OnLevelPointsChanged;
        OnLevelPointsChanged();
        playerLevelNumber.text = _playerLevel.StringLevelNumber();
    }

    private void OnLevelEnd() 
    {
        _playerLevel.LevelPointsChanged -= OnLevelPointsChanged;
    }

    public void OnLevelPointsChanged()
    {
        barImage.fillAmount = _playerLevel.LevelPointsPercent();
        playerLevelNumber.text = _playerLevel.StringLevelNumber();
    }

    private void OnDestroy()
    {
        LevelController.Instance.GameInitialized -= Initialization;
        LevelController.Instance.LevelEnded -= OnLevelEnd;
    }
}
