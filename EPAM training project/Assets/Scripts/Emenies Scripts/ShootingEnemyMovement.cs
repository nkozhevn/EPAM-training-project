using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingEnemyMovement : Enemy
{
    [SerializeField] private List<ShootingEnemyStats> enemyStatsList;
    [SerializeField] private Transform firePoint;
    private ShootingEnemyStats _enemyStats;
    private float _shootingTimer = 99999f;
    //private bool _onShoot;
    private enum State { Running, Shooting }
    private State _state;
    [SerializeField] private Animator animator;
    private int _isWalkingHash;
    private int _onShootHash;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private float effectLifeTime;
 
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        health.HealthChanged += OnHealthChanged;
        _isWalkingHash = Animator.StringToHash("isWalking");
        _onShootHash = Animator.StringToHash("onShoot");
    }

    private void Start()
    {
        //_enemyStats = enemyStatsList[PlayerPrefs.GetInt("Difficulty")];
        _enemyStats = enemyStatsList[GameLoop.Instance.GameData.difficulty];

        navMeshAgent.speed = _enemyStats.MoveSpeed;
    }

    private void Update() 
    {
        Direction = GameLoop.Instance.Player.GetPosition - Rigidbody.position;
        //DirectionNorm = Direction / Direction.magnitude;

        if(Direction.magnitude > _enemyStats.ShootingDist)
        {
            _state = State.Running;
            animator.SetBool(_isWalkingHash, true);
        }
        else
        {
            _state = State.Shooting;
            animator.SetBool(_isWalkingHash, false);
        }
    }

    private void FixedUpdate()
    {
        //_onShoot = !(Direction.magnitude > _enemyStats.ShootingDist);

        //transform.LookAt(GameLoop.Instance.Player.transform);

        //if(navMeshAgent.enabled == true)
        //{
            switch(_state)
            {
                case State.Running:
                    //Rigidbody.MovePosition(Rigidbody.position + DirectionNorm * _enemyStats.MoveSpeed * Time.fixedDeltaTime);
                    navMeshAgent.isStopped = false;
                    _shootingTimer = _enemyStats.ShootingCoolDown;
                    navMeshAgent.destination = GameLoop.Instance.Player.transform.position;
                    break;
                case State.Shooting:
                    transform.LookAt(GameLoop.Instance.Player.transform);
                    navMeshAgent.isStopped = true;
                    //navMeshAgent.destination = transform.position;
                    if(_shootingTimer >= _enemyStats.ShootingCoolDown)
                    {
                        Shoot();
                        animator.SetTrigger(_onShootHash);
                        _shootingTimer = 0;
                    }
                    else
                    {
                        _shootingTimer += Time.deltaTime;
                    }
                    break;
            }
        //}
        /*if(!_onShoot)
        {
            Rigidbody.MovePosition(Rigidbody.position + DirectionNorm * _enemyStats.MoveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            if(_shootingTimer >= _enemyStats.ShootingCoolDown)
            {
                Shoot();
                _shootingTimer = 0;
            }
            else
            {
                _shootingTimer += Time.deltaTime;
            }
        }*/
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_enemyStats.BulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * _enemyStats.BulletForce, ForceMode.Impulse);
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
