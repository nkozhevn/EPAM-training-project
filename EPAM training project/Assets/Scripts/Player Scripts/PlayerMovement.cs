using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _movement;
    private Vector3 _mousePosition;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.z = Input.GetAxisRaw("Vertical");

        _mousePosition = GameLoop.Instance.Player.cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * GameLoop.Instance.Player.moveSpeed * Time.fixedDeltaTime);

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = GameLoop.Instance.Player.cam.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, GameLoop.Instance.Player.turnSpeed * Time.deltaTime);
        }
        /*Vector3 difference = _mousePosition - transform.position; 
        difference.Normalize();
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);*/
    }
}
