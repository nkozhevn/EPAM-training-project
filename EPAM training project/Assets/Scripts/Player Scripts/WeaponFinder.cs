using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponFinder : MonoBehaviour
{
    [SerializeField] public string upgradeName;
    [SerializeField] private Upgrade weaponUpgrade;
    [SerializeField] private Image weaponIcon;
    [SerializeField] public bool weaponGot = false;
    [SerializeField] private Weapon weapon;
    [SerializeField] private PlayerShooting playerShooting;
 
    private void Awake()
    {
        if(GameLoop.Instance.GameData.weapons[upgradeName] == true)
        {
            weaponGot = true;
            playerShooting.Weapons.Add(weapon);
            playerShooting.SelectWeapon(0);
        }
        else
        {
            weaponIcon.enabled = false;
            weaponGot = false;
        }
    }
 
    private void Update()
    {
        if(weaponUpgrade != null)
        {
            if(weaponUpgrade.IsActivated && !weaponGot)
            {
                weaponGot = true;
                playerShooting.Weapons.Add(weapon);
                weaponIcon.enabled = true;
            }
        }
    }
}
