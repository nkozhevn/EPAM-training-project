using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponStats weaponStats;

    private int _currentAmmo = 0;
    private Animation _animation;

    public bool IsReloading { get; private set; }

    public WeaponStats Stats => weaponStats;

    private void Start()
    {
        _currentAmmo = weaponStats.MaxAmmo;
        _animation = transform.GetComponent<Animation>();
    }

    private void OnEnable()
    {
        IsReloading = false;
    }

    public void Shoot()
    {
        if(IsReloading)
        {
            return;
        }
        if(_currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        _currentAmmo--;

        var bullet = Instantiate(weaponStats.BulletPrefab, firePoint.position, firePoint.rotation);
        bullet.AddForce(firePoint.up * weaponStats.BulletForce, ForceMode.Impulse);
    }

    public IEnumerator Reload()
    {
        IsReloading = true;
        _animation.Play();
        yield return new WaitForSeconds(weaponStats.CoolDown);
        _currentAmmo = weaponStats.MaxAmmo;
        IsReloading = false;
    }
}
