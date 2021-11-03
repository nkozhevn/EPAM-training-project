using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingEnemyMovement : Enemy
{
    [SerializeField] private List<ShootingEnemyStats> enemyStatsList;
    private ShootingEnemyStats _enemyStats;
    private float _shootingTimer = 99999f;
    [SerializeField] private Transform firePoint;
    //private bool _onShoot;
    private State _state;
    private enum State { Running, Shooting }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        health.HealthChanged += OnHealthChanged;
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
        }
        else
        {
            _state = State.Shooting;
        }
    }

    private void FixedUpdate()
    {
        //_onShoot = !(Direction.magnitude > _enemyStats.ShootingDist);

        //transform.LookAt(GameLoop.Instance.Player.transform);

        if(navMeshAgent.enabled == true)
        {
            switch(_state)
            {
                case State.Running:
                    //Rigidbody.MovePosition(Rigidbody.position + DirectionNorm * _enemyStats.MoveSpeed * Time.fixedDeltaTime);
                    _shootingTimer = _enemyStats.ShootingCoolDown;
                    navMeshAgent.destination = GameLoop.Instance.Player.transform.position;
                    break;
                case State.Shooting:
                    transform.LookAt(GameLoop.Instance.Player.transform);
                    navMeshAgent.destination = transform.position;
                    if(_shootingTimer >= _enemyStats.ShootingCoolDown)
                    {
                        Shoot();
                        _shootingTimer = 0;
                    }
                    else
                    {
                        _shootingTimer += Time.deltaTime;
                    }
                    break;
            }
        }
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
            Destroy(gameObject);
            GameLoop.Instance.Player.level.GainLevelPoints(levelPoints);
        }
    }
}
