using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    [SerializeField] private Spawn spawner;
    private bool triggered = false;

    private void OnTriggerEnter()
    {
        if(!triggered)
        {
            StartCoroutine(spawner.Spawning());
            triggered = true;
        }
    }
}
