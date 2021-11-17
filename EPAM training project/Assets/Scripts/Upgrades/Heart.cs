using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private int restoreAmount = 5;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private string soundName;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            audioManager.Play(soundName);
            Health health = collider.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.RestoreHealth(restoreAmount);
            }
            Destroy(gameObject);
        }
    }
}
