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
    
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find(objectName).transform;
    }

    private void Update()
    {
        _direction = _player.position - _rb.position;
        _direction = _direction / _direction.magnitude;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * moveSpeed * Time.fixedDeltaTime);
    }
}
