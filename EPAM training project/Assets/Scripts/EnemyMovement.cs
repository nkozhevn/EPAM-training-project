using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float turnSpeed = 10f;
    private Rigidbody rb;
    private Transform player;
    Vector3 direction;
    [SerializeField] private string objectName = "Player";
    
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find(objectName).transform;
    }

    private void Update()
    {
        direction = player.position - rb.position;
        direction = direction / direction.magnitude;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}
