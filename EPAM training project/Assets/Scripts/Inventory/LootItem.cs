using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour
{
    [SerializeField] private InventoryItem _inventoryItem;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private string soundName;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            audioManager.Play(soundName);
            LevelController.Instance.Player.Inventory.AddItem(_inventoryItem);
            gameObject.SetActive(false);
        }
    }
}
