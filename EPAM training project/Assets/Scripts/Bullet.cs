using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private int bulletPower = 1;
    
    private void Awake()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Bullet"))
        {
            return;
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.33f);
        EnemyHealth enemyHealth = collider.gameObject.GetComponent<EnemyHealth>();
        if(enemyHealth != null)
        {
            enemyHealth.DamageEffect(bulletPower);
        }
        Destroy(gameObject);
    }
}
