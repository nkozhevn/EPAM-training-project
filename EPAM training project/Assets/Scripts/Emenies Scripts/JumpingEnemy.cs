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
    private enum State { Running, Jumping, Standing }
    private State _state;

    private void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        health.HealthChanged += OnHealthChanged;
    }

    private void Start()
    {
        _enemyStats = enemyStatsList[GameLoop.Instance.GameData.difficulty];

        navMeshAgent.speed = _enemyStats.MoveSpeed;
    }

    private void Update() 
    {
        Direction = GameLoop.Instance.Player.GetPosition - Rigidbody.position;

        if(Direction.magnitude > _enemyStats.JumpingDist && _state != State.Standing)
        {
            _state = State.Running;
        }
        else if(_state != State.Standing)
        {
            _state = State.Jumping;
        }
    }

    private void LateUpdate()
    {
        //if(navMeshAgent.enabled)
        //{
            switch(_state)
            {
                case State.Running:
                    //navMeshAgent.enabled = true;
                    //if(navMeshAgent.enabled)
                    //{
                        //_jumpingWaitTimer = 0;
                        //navMeshAgent.destination = GameLoop.Instance.Player.transform.position;
                    //}
                    navMeshAgent.isStopped = false;
                    _jumpingWaitTimer = 0;
                    navMeshAgent.destination = GameLoop.Instance.Player.transform.position;
                    break;
                case State.Jumping:
                    transform.LookAt(GameLoop.Instance.Player.transform);
                    //navMeshAgent.enabled = false;
                    navMeshAgent.isStopped = true;
                    if(_jumpingWaitTimer >= _enemyStats.JumpingWaitTime)
                    {
                        Jump();
                        _state = State.Standing;
                        _jumpingWaitTimer = 0;
                    }
                    else
                    {
                        _jumpingWaitTimer += Time.deltaTime;
                    }
                    break;
                case State.Standing:
                    //navMeshAgent.enabled = false;
                    navMeshAgent.isStopped = true;
                    if(_jumpingCoolDownTimer >= _enemyStats.JumpingCoolDown)
                    {
                        _state = State.Running;
                        _jumpingCoolDownTimer = 0;
                    }
                    else
                    {
                        _jumpingCoolDownTimer += Time.deltaTime;
                    }
                    break;
            }
        //}
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
            Destroy(gameObject);
            GameLoop.Instance.Player.level.GainLevelPoints(levelPoints);
        }
    }
}
