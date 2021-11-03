using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : Enemy
{
    [SerializeField] private float moveSpeed = 15f;
    private Vector3 _startPosition;
    private Vector3 _roamPosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _startPosition = transform.position;
    }

    private void Start() 
    {
        _roamPosition = GetRoamingPosition();
    }

    private void Update() {
        Direction = _roamPosition - Rigidbody.position;
        DirectionNorm = Direction / Direction.magnitude;
    }

    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + DirectionNorm * moveSpeed * Time.fixedDeltaTime);
        transform.LookAt(_roamPosition);

        if(Vector3.Distance(transform.position, _roamPosition) < 1f)
        {
            _roamPosition = GetRoamingPosition();
        }
    }

    private Vector3 GetRoamingPosition()
    {
        Vector3 randomDir = new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;
        return _startPosition + randomDir * Random.Range(1f, 10f);
    }
}
