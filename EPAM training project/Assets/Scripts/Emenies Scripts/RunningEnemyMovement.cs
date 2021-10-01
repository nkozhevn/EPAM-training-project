using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemyMovement : MonoBehaviour
{
    [SerializeField] private RunningEnemyStats enemyStats;
    private bool _hitCheck = false;
    [SerializeField] private Enemy enemy;

    private void FixedUpdate()
    {
        if(!_hitCheck)
        {
            enemy.Rigidbody().MovePosition(enemy.Rigidbody().position + enemy.directionNorm * enemyStats.MoveSpeed * Time.fixedDeltaTime);
            transform.LookAt(Player.Instance.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.RecieveDamage(enemyStats.EnemyPower);
                StartCoroutine(Stunning());
            }
        }
    }

    private IEnumerator Stunning()
    {
        _hitCheck = true;
        yield return new WaitForSeconds(enemyStats.StunTime);
        _hitCheck = false;
    }
}
