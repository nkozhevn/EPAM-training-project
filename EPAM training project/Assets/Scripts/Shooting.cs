using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 40f;
    [SerializeField] public float coolDown = 0.1f;

    [SerializeField] private int maxAmmo = 40;
    private int currentAmmo = 0;
    [SerializeField] private float reloadTime = 1f;
    [SerializeField] public bool isReloading = false;
    private Animation animation;

    void Start()
    {
        currentAmmo = maxAmmo;
        animation = transform.GetComponent<Animation>();
    }

    void OnEnable()
    {
        isReloading = false;
    }

    public void Shoot()
    {
        if(isReloading)
        {
            return;
        }
        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        currentAmmo--;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        animation.Play();
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
