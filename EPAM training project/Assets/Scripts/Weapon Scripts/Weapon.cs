using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    public event Action AmmoChanged;
    //[SerializeField] private List<Transform> firePoints;
    [SerializeField] protected WeaponStats weaponStats;
    [SerializeField] private SkillIcon weaponIcon;
    [SerializeField] private Image weaponIconBorder;
    
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

        if(weaponIconBorder != null)
        {
            weaponIconBorder.enabled = true;
        }
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

            /*switch(weaponStats.WeaponType)
            {
                case 1:
                    GunShoot();
                    break;
                case 2:
                    ShotgunShoot();
                    break;
                case 3:
                    LazerShoot();
                    break;
                default:
                    GunShoot();
                    break;
            }*/
            Shoot();

            _shootingTimer = 0;
        }
        else if(_shootingTimer < Stats.CoolDown)
        {
            _shootingTimer += Time.deltaTime;
        }
    }

    private void OnDisable()
    {
        if(weaponIconBorder != null)
        {
            weaponIconBorder.enabled = false;
        }
    }

    public abstract void Shoot();

    /*private void GunShoot()
    {
        CurrentAmmo--;

        var bullet = Instantiate(weaponStats.BulletPrefab, firePoints[0].position, firePoints[0].rotation);
        bullet.AddForce(firePoints[0].up * weaponStats.BulletForce, ForceMode.Impulse);
    }*/

    /*private void ShotgunShoot()
    {
        CurrentAmmo--;

        var bullet = Instantiate(weaponStats.BulletPrefab, firePoints[0].position, firePoints[0].rotation);
        bullet.AddForce(firePoints[0].up * weaponStats.BulletForce, ForceMode.Impulse);
        bullet = Instantiate(weaponStats.BulletPrefab, firePoints[1].position, firePoints[1].rotation);
        bullet.AddForce(firePoints[1].up * weaponStats.BulletForce, ForceMode.Impulse);
        bullet = Instantiate(weaponStats.BulletPrefab, firePoints[2].position, firePoints[2].rotation);
        bullet.AddForce(firePoints[2].up * weaponStats.BulletForce, ForceMode.Impulse);
    }*/

    /*private void LazerShoot()
    {
        CurrentAmmo--;

        var bullet = Instantiate(weaponStats.BulletPrefab, firePoints[0].position, firePoints[0].rotation);
        bullet.AddForce(firePoints[0].up * weaponStats.BulletForce, ForceMode.Impulse);
    }*/

    public IEnumerator Reload()
    {
        IsReloading = true;
        weaponIcon.Reload(weaponStats.ReloadTime);
        _animation.Play();
        yield return new WaitForSeconds(weaponStats.ReloadTime);
        CurrentAmmo = weaponStats.MaxAmmo;
        IsReloading = false;
    }

    public float AmmoPercent => (float)CurrentAmmo / weaponStats.MaxAmmo;
}
