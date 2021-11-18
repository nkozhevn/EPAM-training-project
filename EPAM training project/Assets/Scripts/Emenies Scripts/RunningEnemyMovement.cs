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
    private State _state;
    private int _isWalkingHash;

    private enum State { Running, Standing }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        health.HealthChanged += OnHealthChanged;
        _isWalkingHash = Animator.StringToHash("isWalking");
    }

    private void Start()
    {
        _enemyStats = enemyStatsList[GameLoop.Instance.GameData.difficulty];
        _state = State.Running;
        animator.SetBool(_isWalkingHash, true);

        navMeshAgent.speed = _enemyStats.MoveSpeed;
    }

    private void FixedUpdate()
    {
        if(_state == State.Running)
        {
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
        _state = State.Standing;
        animator.SetBool(_isWalkingHash, false);
        navMeshAgent.isStopped = true;
        yield return new WaitForSeconds(_enemyStats.StunTime);
        _state = State.Running;
        animator.SetBool(_isWalkingHash, true);
        navMeshAgent.isStopped = false;
    }

    public void OnHealthChanged()
    {
        if(health.NoHealth)
        {
            GameLoop.Instance.Player.level.GainLevelPoints(levelPoints);
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, effectLifeTime);
            Destroy(gameObject);
        }
    }
}
