using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyMovement : Enemy
{
    [SerializeField] private List<ShootingEnemyStats> enemyStatsList;
    private ShootingEnemyStats _enemyStats;
    private float _shootingTimer = 99999f;
    [SerializeField] private Transform firePoint;
    private bool _onShoot;

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
        _onShoot = !(Direction.magnitude > _enemyStats.ShootingDist);

        transform.LookAt(Player.Instance.transform);
        if(!_onShoot)
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
        }
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
            Player.Instance.level.GainLevelPoints(levelPoints);
        }
    }
}
