using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 0.1f;
    [SerializeField] private int enemyToSpawn = 10;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private TriggerObjects trigger;
    private int _count;

    public IEnumerator Spawning()
    {
        _count = 0;
        while(_count < enemyToSpawn)
        {
            if(!trigger.IsActivated && LevelController.Instance.IsInitialized)
            {
                var enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
                enemy.Setup(LevelController.Instance.Player);
                _count++;
            }
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
