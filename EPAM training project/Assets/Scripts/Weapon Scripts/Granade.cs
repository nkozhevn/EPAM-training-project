using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    //[SerializeField] private int granadePower = 10;
    [SerializeField] private float timeToExplosion = 3f;
    [SerializeField] private float effectLifetime = 0.33f;
    //private bool _exploded = false;

    private void Awake()
    {
        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(timeToExplosion);
        GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(effect, effectLifetime);
        //_exploded = true;
        Destroy(gameObject);
    }

    /*private void OnTriggerEnter(Collider collider)
    {
        if(_exploded)
        {
            if (collider.gameObject.tag == "Player")
            {
                return;
            }
            Health health = collider.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.RecieveDamage(granadePower);
            }
        }
    }*/
}
