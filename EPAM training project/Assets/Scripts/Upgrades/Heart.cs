using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private int restoreAmount = 5;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Health health = collider.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.RestoreHealth(restoreAmount);
            }
            Destroy(gameObject);
        }
    }
}
