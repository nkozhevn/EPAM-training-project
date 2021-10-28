using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private int bulletPower = 1;
    [SerializeField] private float effectLifetime = 0.33f;
    
    private void Awake()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy") || collider.gameObject.CompareTag("Bullet") || collider.gameObject.CompareTag("Trigger"))
        {
            return;
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, effectLifetime);
        PlayerHealth health = collider.gameObject.GetComponent<PlayerHealth>();
        if(health != null)
        {
            health.RecieveDamage(bulletPower);
        }
        Destroy(gameObject);
    }
}
