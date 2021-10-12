using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RunningEnemyMovement : MonoBehaviour
{
    //[SerializeField] private RunningEnemyStats enemyStats;
    [SerializeField] private List<RunningEnemyStats> enemyStatsList;
    private RunningEnemyStats _enemyStats;
    private bool _hitCheck = false;
    [SerializeField] private Enemy enemy;

    private void Awake()
    {
        _enemyStats = enemyStatsList[PlayerPrefs.GetInt("Difficulty")];
    }

    private void FixedUpdate()
    {
        if(!_hitCheck)
        {
            enemy.Rigidbody().MovePosition(enemy.Rigidbody().position + enemy.directionNorm * _enemyStats.MoveSpeed * Time.fixedDeltaTime);
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
                health.RecieveDamage(_enemyStats.EnemyPower);
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
