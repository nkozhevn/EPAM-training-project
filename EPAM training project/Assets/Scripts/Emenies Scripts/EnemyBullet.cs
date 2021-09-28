using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private int bulletPower = 1;
    
    private void Awake()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Bullet")
        {
            return;
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.33f);
        PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            playerHealth.DamageEffect(bulletPower);
        }
        Destroy(gameObject);
    }
}
