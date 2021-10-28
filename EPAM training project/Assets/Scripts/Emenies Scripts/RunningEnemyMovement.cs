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
        _rb = GetComponent<Rigidbody>();
        health.HealthChanged += OnHealthChanged;

        _enemyStats = enemyStatsList[PlayerPrefs.GetInt("Difficulty")];
    }

    private void Update() 
    {
        Direction = Player.Instance.GetPosition - Rigidbody.position;
        DirectionNorm = Direction / Direction.magnitude;
    }

    private void FixedUpdate()
    {
        if(!_hitCheck)
        {
            Rigidbody.MovePosition(Rigidbody.position + DirectionNorm * _enemyStats.MoveSpeed * Time.fixedDeltaTime);
            transform.LookAt(Player.Instance.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
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

    public void OnHealthChanged()
    {
        if(health.NoHealth)
        {
            Destroy(gameObject);
            Player.Instance.level.GainLevelPoints(levelPoints);
        }
    }
}
