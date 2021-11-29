using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : Enemy
{
    [SerializeField] private List<JumpingEnemyStats> enemyStatsList;
    [SerializeField] private Transform jumpPoint;

    private JumpingEnemyStats _enemyStats;
    private float _jumpingWaitTimer = 99999f;
    private float _jumpingCoolDownTimer = 0f; 
    private State _state;
    private int _isWalkingHash;
    private int _isJumpingHash;
    
    private enum State { Running, Jumping, Standing }

    private void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        health.HealthChanged += OnHealthChanged;
        _isWalkingHash = Animator.StringToHash("isWalking");
        _isJumpingHash = Animator.StringToHash("isJumping");
    }

    private void Start()
    {
        _enemyStats = enemyStatsList[LevelController.Instance.GameData.difficulty];

        navMeshAgent.speed = _enemyStats.MoveSpeed;
    }

    private void Update() 
    {
        Direction = LevelController.Instance.Player.GetPosition - Rigidbody.position;

        if(Direction.magnitude > _enemyStats.JumpingDist && _state != State.Standing)
        {
            _state = State.Running;
            animator.SetBool(_isWalkingHash, true);
            animator.SetBool(_isJumpingHash, false);
        }
        else if(_state != State.Standing)
        {
            _state = State.Jumping;
            animator.SetBool(_isWalkingHash, false);
            animator.SetBool(_isJumpingHash, false);
        }
    }

    private void LateUpdate()
    {
        switch(_state)
        {
            case State.Running:
                navMeshAgent.isStopped = false;
                _jumpingWaitTimer = 0;
                navMeshAgent.destination = LevelController.Instance.Player.transform.position;
                break;
            case State.Jumping:
                transform.LookAt(LevelController.Instance.Player.transform);
                navMeshAgent.isStopped = true;
                if(_jumpingWaitTimer >= _enemyStats.JumpingWaitTime)
                {
                    Jump();
                    animator.SetBool(_isWalkingHash, false);
                    animator.SetBool(_isJumpingHash, true);
                    _state = State.Standing;
                    _jumpingWaitTimer = 0;
                }
                else
                {
                    _jumpingWaitTimer += Time.deltaTime;
                }
                break;
            case State.Standing:
                navMeshAgent.isStopped = true;
                if(_jumpingCoolDownTimer >= _enemyStats.JumpingCoolDown)
                {
                    _state = State.Running;
                    animator.SetBool(_isWalkingHash, true);
                    animator.SetBool(_isJumpingHash, false);
                    _jumpingCoolDownTimer = 0;
                }
                else
                {
                    _jumpingCoolDownTimer += Time.deltaTime;
                }
                break;
        }
    }

    private void Jump()
    {
        Rigidbody.AddForce(jumpPoint.up * _enemyStats.JumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            if(health != null)
            {
                health.RecieveDamage(_enemyStats.EnemyPower);
            }
        }
    }

    public void OnHealthChanged()
    {
        if(health.NoHealth)
        {
            LevelController.Instance.Player.PlayerLevel.GainLevelPoints(levelPoints);
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, effectLifeTime);
            Destroy(gameObject);
        }
    }
}
