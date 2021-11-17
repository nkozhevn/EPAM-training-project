using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private bool _isActivated = false;
    public bool IsActivated => _isActivated;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private string soundName;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            audioManager.Play(soundName);
            _isActivated = true;
            gameObject.SetActive(false);
        }
    }
}
