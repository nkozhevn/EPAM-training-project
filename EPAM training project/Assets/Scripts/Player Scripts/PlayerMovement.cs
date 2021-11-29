using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource walkingAudio;

    private Vector3 _movement;
    private Vector3 _mousePosition;
    private Rigidbody _rigidbody;
    private bool _isMoving = false;
    private int _isWalkingHash;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isWalkingHash = Animator.StringToHash("isWalking");
        walkingAudio.Play();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.z = Input.GetAxisRaw("Vertical");

        _mousePosition = LevelController.Instance.Player.cam.ScreenToWorldPoint(Input.mousePosition);

        if(_movement.magnitude >= 0.1f)
        {
            _isMoving = true;
            animator.SetBool(_isWalkingHash, true);
            walkingAudio.mute = false;
        }
        else
        {
            _isMoving = false;
            animator.SetBool(_isWalkingHash, false);
            walkingAudio.mute = true;
        }
    }

    private void FixedUpdate()
    {
        if(_isMoving)
        {
            _rigidbody.MovePosition(_rigidbody.position + _movement * LevelController.Instance.Player.PlayerStats.MoveSpeed * Time.fixedDeltaTime);
        }

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = LevelController.Instance.Player.cam.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, LevelController.Instance.Player.PlayerStats.TurnSpeed * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        walkingAudio.mute = true;
    }
}
