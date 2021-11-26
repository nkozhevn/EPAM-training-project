using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour, ICamera
{
    [SerializeField] private float smoothSpeed = 0.25f;
    [SerializeField] private Vector3 offset;

    public void SetTarget(Transform target)
    {
        _target = target;
    }



    private void LateUpdate()
    {
        if (_target == null)
            return;


        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
