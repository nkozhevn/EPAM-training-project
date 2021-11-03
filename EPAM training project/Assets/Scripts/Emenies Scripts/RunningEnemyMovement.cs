using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class RunningEnemyMovement : Enemy
{
    [SerializeField] private List<RunningEnemyStats> enemyStatsList;
    private RunningEnemyStats _enemyStats;
    private bool _hitCheck = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        health.HealthChanged += OnHealthChanged;

        //_enemyStats = enemyStatsList[PlayerPrefs.GetInt("Difficulty")];
        _enemyStats = enemyStatsList[GameLoop.Instance.GameData.difficulty];
    }

    private void Update() 
    {
        //Direction = GameLoop.Instance.Player.GetPosition - Rigidbody.position;
        //DirectionNorm = Direction / Direction.magnitude;
    }

    private void FixedUpdate()
    {
        if(!_hitCheck)
        {
            //Rigidbody.MovePosition(Rigidbody.position + DirectionNorm * _enemyStats.MoveSpeed * Time.fixedDeltaTime);
            transform.LookAt(GameLoop.Instance.Player.transform);
            navMeshAgent.destination = GameLoop.Instance.Player.transform.position;
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
            GameLoop.Instance.Player.level.GainLevelPoints(levelPoints);
        }
    }
}
