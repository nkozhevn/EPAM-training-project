using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon, IWeapon
{
    [SerializeField] private Transform firePoint;

    public override void Shoot()
    {
        CurrentAmmo--;

        var bullet = Instantiate(weaponStats.BulletPrefab, firePoint.position, firePoint.rotation);
        bullet.AddForce(firePoint.up * weaponStats.BulletForce, ForceMode.Impulse);
    }
}
