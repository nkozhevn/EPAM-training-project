using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RunningEnemyMovement : Enemy
{
    [SerializeField] private List<RunningEnemyStats> enemyStatsList;
    private RunningEnemyStats _enemyStats;
    private bool _hitCheck = false;

    private void Awake()
    {
        _enemyStats = enemyStatsList[PlayerPrefs.GetInt("Difficulty")];
    }

    private void FixedUpdate()
    {
        if(!_hitCheck)
        {
            Rigidbody.MovePosition(Rigidbody.position + DirectionNorm * (_enemyStats.MoveSpeed * Time.fixedDeltaTime));
            transform.LookAt(Player.Instance.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.ReceiveDamage(_enemyStats.EnemyPower);
                StartCoroutine(Stunning());
            }
        }
    }

    private IEnumerator Stunning()
    {
        _hitCheck = true;
        yield return new WaitForSeconds(_enemyStats.StunTime);
        _hitCheck = false;
    }
}
