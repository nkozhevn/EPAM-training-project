using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] private Image barImage;
    private PlayerShooting _playerShooting;
    [SerializeField] private Image weaponPic;
    [SerializeField] private List<Sprite> weaponImages;
    [SerializeField] private List<SkillIcon> itemIcons;
    public List<SkillIcon> ItemIcons => itemIcons;

    private int _weaponImageIndex = 0;
    private Weapon _selectedWeapon;

    private void Awake()
    {
        LevelController.Instance.GameInitialized += Initialization;
        LevelController.Instance.LevelEnded += OnLevelEnd;
    }

    private void Initialization()
    {
        _playerShooting = LevelController.Instance.Player.PlayerShooting;
        _selectedWeapon = _playerShooting.SelectedWeapon;
        _selectedWeapon.AmmoChanged += OnAmmoChanged;
        _playerShooting.WeaponChanged += OnWeaponChanged;

        _weaponImageIndex = _playerShooting.SelectedWeaponIndex;
        weaponPic.sprite = weaponImages[_weaponImageIndex];
    }

    private void OnLevelEnd()
    {
        _selectedWeapon.AmmoChanged -= OnAmmoChanged;
        _playerShooting.WeaponChanged -= OnWeaponChanged;
    }

    public void OnAmmoChanged()
    {
        barImage.fillAmount = _selectedWeapon.AmmoPercent;
    }

    public void OnWeaponChanged(Weapon selectedWeapon)
    {
        _selectedWeapon.AmmoChanged -= OnAmmoChanged;
        _weaponImageIndex = _playerShooting.SelectedWeaponIndex;
        weaponPic.sprite = weaponImages[_weaponImageIndex];
        _selectedWeapon = selectedWeapon;
        barImage.fillAmount = _selectedWeapon.AmmoPercent;
        _selectedWeapon.AmmoChanged += OnAmmoChanged;
    }

    private void OnDestroy()
    {
        LevelController.Instance.GameInitialized -= Initialization;
        LevelController.Instance.GameInitialized -= OnLevelEnd;
    }
}
