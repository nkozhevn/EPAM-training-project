using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeExplosion : MonoBehaviour
{
    [SerializeField] private int granadePower = 10;

    private void OnTriggerEnter(Collider collider)
    {
        Health health = collider.gameObject.GetComponent<Health>();
        if(health != null)
        {
            health.RecieveDamage(granadePower);
        }
    }
}
