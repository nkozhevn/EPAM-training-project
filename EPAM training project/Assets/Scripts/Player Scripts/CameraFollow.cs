using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float smoothSpeed = 0.25f;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        LevelController.Instance.GameInitialized += Initialization;
    }

    private void Initialization()
    {
        _target = LevelController.Instance.Player.gameObject.transform;
        LevelController.Instance.Player.cam = gameObject.GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = _target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

    private void OnDestroy()
    {
        LevelController.Instance.GameInitialized -= Initialization;
    }
}
