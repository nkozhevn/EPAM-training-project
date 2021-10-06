using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private PlayerShooting playerShooting;
    [SerializeField] private Image weaponPic;
    [SerializeField] private List<Sprite> weaponImages;
    private int _weaponImageIndex = 0;
    private Weapon _selectedWeapon;


    private void Start()
    {
        _selectedWeapon = playerShooting.SelectedWeapon;
        _selectedWeapon.AmmoChanged += OnAmmoChanged;
        playerShooting.WeaponChanged += OnWeaponChanged;

        _weaponImageIndex = playerShooting.SelectedWeaponIndex;
        weaponPic.sprite = weaponImages[_weaponImageIndex];
    }

    private void OnDestroy()
    {
        _selectedWeapon.AmmoChanged -= OnAmmoChanged;
        playerShooting.WeaponChanged -= OnWeaponChanged;
    }

    public void OnAmmoChanged()
    {
        barImage.fillAmount = _selectedWeapon.AmmoPercent;
    }

    public void OnWeaponChanged(Weapon selectedWeapon)
    {
        _selectedWeapon.AmmoChanged -= OnAmmoChanged;
        _weaponImageIndex = playerShooting.SelectedWeaponIndex;
        weaponPic.sprite = weaponImages[_weaponImageIndex];
        _selectedWeapon = selectedWeapon;
        barImage.fillAmount = _selectedWeapon.AmmoPercent;
        _selectedWeapon.AmmoChanged += OnAmmoChanged;
    }
}
