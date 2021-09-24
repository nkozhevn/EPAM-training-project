using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 10f;
    private Rigidbody _rb;
    [SerializeField] private Camera cam;
    private Vector3 _movement;
    private Vector3 _mousePosition;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.z = Input.GetAxisRaw("Vertical");

        _mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
        /*Vector3 difference = _mousePosition - transform.position; 
        difference.Normalize();
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);*/
    }
}
