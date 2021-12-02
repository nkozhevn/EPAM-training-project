using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;
    
    private bool triggered = false;

    private void OnTriggerEnter(Collider collider)
    {
        if(!triggered)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                StartCoroutine(spawner.Spawning());
                triggered = true;
            }
        }
    }
}
