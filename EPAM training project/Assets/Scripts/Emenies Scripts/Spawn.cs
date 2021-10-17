using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 0.1f;
    [SerializeField] private int enemyToSpawn = 10;
    [SerializeField] private GameObject enemyPrefab;
    private int _count;
    [SerializeField] private TriggerObjects trigger;

    public IEnumerator Spawning()
    {
        _count = 0;
        while(_count < enemyToSpawn)
        {
            if(!trigger.IsActivated())
            {
                Instantiate(enemyPrefab, transform.position, transform.rotation);
                _count++;
            }
            yield return new WaitForSeconds(spawnTimer);
        }
        
    }
}
