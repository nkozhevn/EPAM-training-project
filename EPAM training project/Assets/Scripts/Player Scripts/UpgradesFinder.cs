using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesFinder : MonoBehaviour
{
    /*[SerializeField] private PlayerShooting playerShooting;
    [SerializeField] private Weapon shotgunPrefab;
    [SerializeField] private Upgrade shotgunUpgrade;
    [SerializeField] private Image shotgunIcon;
    [SerializeField] public bool shotgunGot = false;
    [SerializeField] private Weapon riflePrefab;
    [SerializeField] private Upgrade rifleUpgrade;
    [SerializeField] private Image rifleIcon;
    [SerializeField] public bool rifleGot = false;*/
    [SerializeField] private Upgrade granadeUpgrade;
    [SerializeField] private Image granadeIcon;
    [SerializeField] public bool granadeGot = false;

    private void Start()
    {
        /*if(PlayerPrefs.GetInt("Shotgun", 0) == 0)
        {
            shotgunIcon.enabled = false;
        }
        else
        {
            playerShooting.weapons.Add(shotgunPrefab);
            shotgunGot = true;
        }

        if(PlayerPrefs.GetInt("Rifle", 0) == 0)
        {
            rifleIcon.enabled = false;
        }
        else
        {
            playerShooting.weapons.Add(riflePrefab);
            rifleGot = true;
        }*/

        if(PlayerPrefs.GetInt("Granade", 0) == 0)
        {
            granadeIcon.enabled = false;
        }
        else
        {
            granadeGot = true;
        }
    }

    private void Update()
    {
        /*if(shotgunUpgrade != null)
        {
            if(shotgunUpgrade.IsActivated)
            {
                playerShooting.weapons.Add(shotgunPrefab);
                shotgunGot = true;
                PlayerPrefs.SetInt("Shotgun", 1);
                shotgunIcon.enabled = true;
            } 
        }

        if(rifleUpgrade != null)
        {
            if(rifleUpgrade.IsActivated)
            {
                playerShooting.weapons.Add(riflePrefab);
                rifleGot = true;
                PlayerPrefs.SetInt("Rifle", 1);
                rifleIcon.enabled = true;
            } 
        }*/

        if(granadeUpgrade != null)
        {
            if(granadeUpgrade.IsActivated)
            {
                granadeGot = true;
                PlayerPrefs.SetInt("Granade", 1);
                granadeIcon.enabled = true;
            } 
        } 
    }
}
