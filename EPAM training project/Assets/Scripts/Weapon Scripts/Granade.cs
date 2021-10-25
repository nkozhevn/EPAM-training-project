using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float timeToExplosion = 3f;
    [SerializeField] private float effectLifetime = 0.33f;

    private void Awake()
    {
        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(timeToExplosion);
        GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(effect, effectLifetime);
        Destroy(gameObject);
    }
}
