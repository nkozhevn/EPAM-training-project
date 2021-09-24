using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float turnSpeed = 10f;
    private Rigidbody _rb;
    private Transform _player;
    private Vector3 _direction;
    [SerializeField] private string objectName = "Player";
    [SerializeField] private int enemyPower = 3;
    [SerializeField] private float stunTime = 3f;
    private bool _hitCheck = true;
    private GameObject _playerCheck;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerCheck = GameObject.Find(objectName);
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
            _direction.Normalize();
        }
    }

    private void FixedUpdate()
    {
        if(_hitCheck && _playerCheck != null)
        {
            _rb.MovePosition(_rb.position + _direction * moveSpeed * Time.fixedDeltaTime);
            _rb.rotation = Quaternion.Euler(_direction);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerDamage playerDamage = collision.gameObject.GetComponent<PlayerDamage>();
            if(playerDamage != null)
            {
                playerDamage.DamageEffect(enemyPower);
                StartCoroutine(Stunning());
            }
        }
    }

    private IEnumerator Stunning()
    {
        _hitCheck = false;
        yield return new WaitForSeconds(stunTime);
        _hitCheck = true;
    }
}
