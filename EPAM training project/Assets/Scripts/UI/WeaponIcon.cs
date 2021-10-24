using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Image image;

    private void Awake() 
    {
        weapon.Reloaded += OnReloaded;
    }

    private void Update()
    {
        if(image.fillAmount > 0)
        {
            image.fillAmount -= Time.deltaTime / weapon.Stats.ReloadTime;
        }
    }

    public void OnReloaded()
    {
        image.fillAmount = 1;
    }

    private void OnDestroy()
    {
        weapon.Reloaded -= OnReloaded;
    }
}
