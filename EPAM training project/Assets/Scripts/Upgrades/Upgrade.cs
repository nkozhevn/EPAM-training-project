using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private bool _isActivated = false;
    public bool IsActivated => _isActivated;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _isActivated = true;
            Destroy(gameObject);
        }
    }
}
