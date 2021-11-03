using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private UnityEngine.AI.NavMeshAgent enemy;
    private bool triggered = false;

    private void OnTriggerEnter(Collider collider)
    {
        if(!triggered)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                enemy.enabled = true;
                triggered = true;
            }
        }
    }
}
