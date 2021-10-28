using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon, IWeapon
{
    [SerializeField] private List<Transform> firePoints;

    public override void Shoot()
    {
        CurrentAmmo--;

        var bullet = Instantiate(weaponStats.BulletPrefab, firePoints[0].position, firePoints[0].rotation);
        bullet.AddForce(firePoints[0].up * weaponStats.BulletForce, ForceMode.Impulse);
        bullet = Instantiate(weaponStats.BulletPrefab, firePoints[1].position, firePoints[1].rotation);
        bullet.AddForce(firePoints[1].up * weaponStats.BulletForce, ForceMode.Impulse);
        bullet = Instantiate(weaponStats.BulletPrefab, firePoints[2].position, firePoints[2].rotation);
        bullet.AddForce(firePoints[2].up * weaponStats.BulletForce, ForceMode.Impulse);
    }
}
