using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAndShoot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float turnSpeed = 10f;
    private Rigidbody _rb;
    private Transform _player;
    private Vector3 _direction;
    private Vector3 _directionNorm;
    [SerializeField] private string targetName = "/Player";
    private GameObject _playerCheck;
    [SerializeField] private float shootingDist = 50f;
    [SerializeField] private float shootingCoolDown = 0.5f;
    private float _shootingTimer = 99999f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 40f;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerCheck = GameObject.Find(targetName);
        if(_playerCheck != null)
        {
            _player = _playerCheck.transform;
        }
    }

    private void Update()
    {
        if(_playerCheck != null)
        {
            _direction = _player.position - _rb.position;
            _directionNorm = _direction / _direction.magnitude;
        }
    }

    private void FixedUpdate()
    {
        if(_playerCheck != null)
        {
            if(_direction.magnitude > shootingDist)
            {
                _rb.MovePosition(_rb.position + _directionNorm * moveSpeed * Time.fixedDeltaTime);
                _rb.rotation = Quaternion.Euler(_directionNorm);
            }
            else
            {
                if(_shootingTimer >= shootingCoolDown)
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
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
    }
}
