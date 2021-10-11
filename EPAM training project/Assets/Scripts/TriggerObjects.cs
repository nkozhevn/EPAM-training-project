using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjects : MonoBehaviour
{
    private bool _isActivated = false;

    public bool IsActivated() => _isActivated;

    private void OnTriggerEnter()
    {
        _isActivated = true;
    }
}
