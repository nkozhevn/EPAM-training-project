using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 40f;
    [SerializeField] public float coolDown = 0.1f;

    [SerializeField] private int maxAmmo = 40;
    private int _currentAmmo = 0;
    [SerializeField] private float reloadTime = 1f;
    [SerializeField] public bool isReloading = false;
    private Animation _animation;

    private void Start()
    {
        _currentAmmo = maxAmmo;
        _animation = transform.GetComponent<Animation>();
    }

    private void OnEnable()
    {
        isReloading = false;
    }

    public void Shoot()
    {
        if(isReloading)
        {
            return;
        }
        if(_currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        _currentAmmo--;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        _animation.Play();
        yield return new WaitForSeconds(reloadTime);
        _currentAmmo = maxAmmo;
        isReloading = false;
    }
}
