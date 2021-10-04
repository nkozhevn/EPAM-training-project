using System.Collections;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour
{
    public event Action AmmoChanged;
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponStats weaponStats;
    
    private float _shootingTimer = 99999f;
    private int _currentAmmo = 0;
    public bool IsReloading{ get; private set; }
    public bool OnShoot;
    public WeaponStats Stats => weaponStats;
    private Animation _animation;
    public int CurrentAmmo
    {
        get => _currentAmmo;
        set
        {
            _currentAmmo = value;
            AmmoChanged?.Invoke();
        }
    }

    private void Start()
    {
        CurrentAmmo = weaponStats.MaxAmmo;
        _animation = transform.GetComponent<Animation>();
    }

    private void OnEnable()
    {
        IsReloading = false;
        OnShoot = false;
    }

    private void Update()
    {
        if(OnShoot && _shootingTimer >= Stats.CoolDown)
        {
            if(IsReloading)
            {
                return;
            }
            if(CurrentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }
            
            Shoot();

            _shootingTimer = 0;
        }
        else if(_shootingTimer < Stats.CoolDown)
        {
            _shootingTimer += Time.deltaTime;
        }
    }

    private void Shoot()
    {
        CurrentAmmo--;

        var bullet = Instantiate(weaponStats.BulletPrefab, firePoint.position, firePoint.rotation);
        bullet.AddForce(firePoint.up * weaponStats.BulletForce, ForceMode.Impulse);
    }

    public IEnumerator Reload()
    {
        IsReloading = true;
        _animation.Play();
        yield return new WaitForSeconds(weaponStats.ReloadTime);
        CurrentAmmo = weaponStats.MaxAmmo;
        IsReloading = false;
    }

    public float AmmoPercent() => (float)CurrentAmmo / weaponStats.MaxAmmo;
}
