using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject hitEffect;
    
    void Awake()
    {
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Bullet")
        {
            return;
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.33f);
        Damage damage = collider.gameObject.GetComponent<Damage>();
        if(damage != null)
        {
            damage.DamageEffect();
        }
        Destroy(gameObject);
    }
}
