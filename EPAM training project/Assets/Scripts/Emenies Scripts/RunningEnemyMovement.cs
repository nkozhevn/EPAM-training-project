using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    private Rigidbody _rb;
    private Vector3 _direction;
    [SerializeField] private string objectName = "Player";
    [SerializeField] private int enemyPower = 3;
    [SerializeField] private float stunTime = 3f;
    private bool _hitCheck = true;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _direction = Player.Instance.GetPosition() - _rb.position;
        _direction.Normalize();
    }

    private void FixedUpdate()
    {
        if(_hitCheck)
        {
            _rb.MovePosition(_rb.position + _direction * moveSpeed * Time.fixedDeltaTime);
            transform.LookAt(Player.Instance.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.RecieveDamage(enemyPower);
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
