using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private bool triggered = false;

    private void Start()
    {
        enemy.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(!triggered)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                enemy.SetActive(true);
                triggered = true;
            }
        }
    }
}
