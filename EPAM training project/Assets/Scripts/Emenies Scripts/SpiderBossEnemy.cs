using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBossEnemy : Enemy
{
    [SerializeField] private List<SpiderBossStats> enemyStatsList;
    private SpiderBossStats _enemyStats;
    [SerializeField] private Transform firePoint;
    float _shootingTimer = 99999f;
    float _launchingTimer = 99999f;
    private State _state = State.Running;
    private enum State { Running, Standing, Shooting, Launching, Dashing }
    //private int _abilitiesCount = Enum.GetNames(typeof(State)).Length - 2;

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

        //if(_state == State.Running)
        //{
            if(Direction.magnitude > _enemyStats.ActivationDist)
            {
                navMeshAgent.speed = _enemyStats.MoveSpeed;
            }
            else if(_state == State.Running)
            {
                navMeshAgent.isStopped = true;
                //navMeshAgent.destination = transform.position;
                int abilityNum = Random.Range(0, 3);
                switch(abilityNum)
                {
                    case 0: 
                        StartCoroutine(AttackActivate(State.Shooting, _enemyStats.ShootingWaitTime, _enemyStats.ShootingActiveTime, _enemyStats.ShootingReloadTime));
                        break;
                    case 1: 
                        StartCoroutine(AttackActivate(State.Launching, _enemyStats.LaunchingWaitTime, _enemyStats.LaunchingActiveTime, _enemyStats.LaunchingReloadTime));
                        break;
                    case 2: 
                        StartCoroutine(AttackActivate(State.Dashing, _enemyStats.DashWaitTime, _enemyStats.DashActiveTime, _enemyStats.DashReloadTime));
                        break;
                }
            }
        //}
    }

    private void LateUpdate()
    {
        //if(navMeshAgent.enabled == true)
        //{
            switch(_state)
            {
                case State.Running:
                    navMeshAgent.isStopped = false;
                    navMeshAgent.destination = GameLoop.Instance.Player.transform.position;
                    break;
                case State.Standing:
                    transform.LookAt(GameLoop.Instance.Player.transform);
                    break;
                case State.Shooting:
                    transform.LookAt(GameLoop.Instance.Player.transform);
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
                case State.Launching:
                    transform.LookAt(GameLoop.Instance.Player.transform);
                    if(_launchingTimer >= _enemyStats.LaunchingCoolDown)
                    {
                        Launch();
                        _launchingTimer = 0;
                    }
                    else
                    {
                        _launchingTimer += Time.deltaTime;
                    }
                    break;
                case State.Dashing:
                    navMeshAgent.isStopped = false;
                    navMeshAgent.destination = GameLoop.Instance.Player.transform.position;
                    break;
            }
        //}
    }

    private IEnumerator AttackActivate(State state, float waitTime, float activeTime, float coolDown)
    {
        _state = State.Standing;
        yield return new WaitForSeconds(waitTime);
        _state = state;
        yield return new WaitForSeconds(activeTime);
        _state = State.Standing;
        yield return new WaitForSeconds(coolDown);
        _state = State.Running;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_enemyStats.BulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * _enemyStats.BulletForce, ForceMode.Impulse);
    }

    private void Launch()
    {
        var granade = Instantiate(_enemyStats.GranadePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = granade.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * _enemyStats.GranadeForce, ForceMode.Impulse);
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
            GameLoop.Instance.objective = true;
            Destroy(gameObject);
            GameLoop.Instance.Player.level.GainLevelPoints(levelPoints);
        }
    }
}
