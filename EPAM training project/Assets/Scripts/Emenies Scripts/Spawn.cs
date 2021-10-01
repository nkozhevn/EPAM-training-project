using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 1f;
    [SerializeField] private int enemyToSpawn = 20;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<Transform> spawners;
    private Transform _currentSpawner;
    private int _count;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        _count = 0;
        while(_count < enemyToSpawn)
        {
            yield return new WaitForSeconds(spawnTimer);
            _currentSpawner = spawners[Random.Range(0, spawners.Count)];
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], _currentSpawner.position, _currentSpawner.rotation);
            _count++;
        }
        
    }
}
