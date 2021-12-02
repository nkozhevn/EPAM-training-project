using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private bool triggered = false;

    private void Awake()
    {
        enemy.gameObject.SetActive(false);
    }

    private void Start()
    {
        LevelController.Instance.GameInitialized += SetupEnemy;
    }

    private void SetupEnemy()
    {
        enemy.Setup(LevelController.Instance.Player);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(!triggered)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                enemy.gameObject.SetActive(true);
                triggered = true;
            }
        }
    }

    private void OnDestroy()
    {
        LevelController.Instance.GameInitialized -= SetupEnemy;
    }
}
