using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnTimer = 1f;
    [SerializeField] private int enemyToSpawn = 20;
    private List<Transform> spawners = new List<Transform>();
    private Transform currentSpawner;
    private int count;

    // Start is called before the first frame update
    private void Start()
    {
        foreach(Transform child in transform)
        {
            spawners.Add(child);
        }
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        count = 0;
        while(count < enemyToSpawn)
        {
            yield return new WaitForSeconds(spawnTimer);
            currentSpawner = spawners[Random.Range(0, spawners.Count)];
            Instantiate(enemyPrefab, currentSpawner.position, currentSpawner.rotation);
            count++;
        }
        
    }
}
