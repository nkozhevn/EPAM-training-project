using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private PlayerShooting playerShooting;
    [SerializeField] private List<GameObject> weaponImages;
    private int _weaponImageIndex = 0;


    private void Start()
    {
        playerShooting.SelectedWeapon.AmmoChanged += OnAmmoChanged;
        playerShooting.WeaponChanged += OnWeaponChanged;
    }

    private void OnDestroy()
    {
        playerShooting.SelectedWeapon.AmmoChanged -= OnAmmoChanged;
        playerShooting.WeaponChanged -= OnWeaponChanged;
    }

    public void OnAmmoChanged()
    {
        barImage.fillAmount = playerShooting.SelectedWeapon.AmmoPercent();
    }

    public void OnWeaponChanged()
    {
        weaponImages[_weaponImageIndex].SetActive(false);
        _weaponImageIndex = playerShooting.SelectedWeaponIndex;
        weaponImages[_weaponImageIndex].SetActive(true);
    }
}
