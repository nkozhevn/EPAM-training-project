using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyMovement : MonoBehaviour
{
    [SerializeField] private ShootingEnemyStats enemyStats;
    private float _shootingTimer = 99999f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Enemy enemy;
    private bool _onShoot;

    private void Awake()
    {
        Player.Instance.PlayerDied += OnPlayerDied;
    }

    private void FixedUpdate()
    {
        _onShoot = !(enemy.direction.magnitude > enemyStats.ShootingDist);

        transform.LookAt(Player.Instance.transform);
        if(!_onShoot)
        {
            enemy.Rigidbody().MovePosition(enemy.Rigidbody().position + enemy.directionNorm * enemyStats.MoveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            if(_shootingTimer >= enemyStats.ShootingCoolDown)
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
        GameObject bullet = Instantiate(enemyStats.BulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * enemyStats.BulletForce, ForceMode.Impulse);
    }

    private void OnPlayerDied()
    {
        this.enabled = false;
    }

    private void OnDestroy()
    {
        Player.Instance.PlayerDied -= OnPlayerDied;
    }
}
