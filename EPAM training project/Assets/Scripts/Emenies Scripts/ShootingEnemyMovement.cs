using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyMovement : MonoBehaviour
{
    [SerializeField] private List<ShootingEnemyStats> enemyStatsList;
    private ShootingEnemyStats _enemyStats;
    private float _shootingTimer = 99999f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Enemy enemy;
    private bool _onShoot;

    private void Awake()
    {
        _enemyStats = enemyStatsList[PlayerPrefs.GetInt("Difficulty")];
    }

    private void FixedUpdate()
    {
        _onShoot = !(enemy.direction.magnitude > _enemyStats.ShootingDist);

        transform.LookAt(Player.Instance.transform);
        if(!_onShoot)
        {
            enemy.Rigidbody().MovePosition(enemy.Rigidbody().position + enemy.directionNorm * _enemyStats.MoveSpeed * Time.fixedDeltaTime);
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
}
