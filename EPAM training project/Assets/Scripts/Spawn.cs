using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnTimer = 1f;
    [SerializeField] private int enemyToSpawn = 20;
    private List<Transform> _spawners = new List<Transform>();
    private Transform _currentSpawner;
    private int _count;

    // Start is called before the first frame update
    private void Start()
    {
        foreach(Transform child in transform)
        {
            _spawners.Add(child);
        }
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        _count = 0;
        while(_count < enemyToSpawn)
        {
            yield return new WaitForSeconds(spawnTimer);
            _currentSpawner = _spawners[Random.Range(0, _spawners.Count)];
            Instantiate(enemyPrefab, _currentSpawner.position, _currentSpawner.rotation);
            _count++;
        }
        
    }
}
