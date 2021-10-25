using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeExplosion : MonoBehaviour
{
    [SerializeField] private int granadePower = 10;

    private void OnTriggerEnter(Collider collider)
    {
        /*if (collider.gameObject.tag == "Player")
        {
            return;
        }*/
        Health health = collider.gameObject.GetComponent<Health>();
        if(health != null)
        {
            health.RecieveDamage(granadePower);
        }
    }
}
