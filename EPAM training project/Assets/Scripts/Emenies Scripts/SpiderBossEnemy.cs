using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBossEnemy : Enemy
{
    [SerializeField] private List<SpiderBossStats> enemyStatsList;
    [SerializeField] private Transform firePoint;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private string soundName;

    private SpiderBossStats _enemyStats;
    float _shootingTimer = 99999f;
    float _launchingTimer = 99999f;
    private State _state;
    private int _isWalkingHash;
    private int _isRunningHash;

    private enum State { Running, Standing, Shooting, Launching, Dashing }

    private void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        health.HealthChanged += OnHealthChanged;
        _isWalkingHash = Animator.StringToHash("isWalking");
        _isRunningHash = Animator.StringToHash("isRunning");
    }

    private void Start()
    {
        _enemyStats = enemyStatsList[LevelController.Instance.GameData.difficulty];

        navMeshAgent.speed = _enemyStats.MoveSpeed;
        _state = State.Running;
        animator.SetBool(_isWalkingHash, true);
    }

    private void OnEnable()
    {
        audioManager.Play(soundName);
    }

    private void Update()
    {
        Direction = Player.transform.position - Rigidbody.position;

        if(Direction.magnitude > _enemyStats.ActivationDist)
        {
            navMeshAgent.speed = _enemyStats.MoveSpeed;
        }
        else if(_state == State.Running)
        {
            navMeshAgent.isStopped = true;
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

    }

    private void LateUpdate()
    {
        switch(_state)
        {
            case State.Running:
                navMeshAgent.isStopped = false;
                navMeshAgent.destination = Player.transform.position;
                break;
            case State.Standing:
                transform.LookAt(Player.transform);
                break;
            case State.Shooting:
                transform.LookAt(Player.transform);
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
                transform.LookAt(Player.transform);
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
                navMeshAgent.destination = Player.transform.position;
                animator.SetBool(_isWalkingHash, false);
                animator.SetBool(_isRunningHash, true);
                break;
        }
    }

    private IEnumerator AttackActivate(State state, float waitTime, float activeTime, float coolDown)
    {
        _state = State.Standing;
        animator.SetBool(_isWalkingHash, false);
        yield return new WaitForSeconds(waitTime);
        _state = state;
        yield return new WaitForSeconds(activeTime);
        _state = State.Standing;
        yield return new WaitForSeconds(coolDown);
        _state = State.Running;
        animator.SetBool(_isWalkingHash, true);
        animator.SetBool(_isRunningHash, false);
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

    private void OnDisable()
    {
        audioManager.Stop(soundName);
    }

    public void OnHealthChanged()
    {
        if(health.NoHealth)
        {
            audioManager.Stop(soundName);
            LevelController.Instance.objective = true;
            Player.PlayerLevel.GainLevelPoints(levelPoints);
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, effectLifeTime);
            Destroy(gameObject);
        }
    }
}
