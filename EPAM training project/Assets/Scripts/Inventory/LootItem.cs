using UnityEngine;

public class LootItem : MonoBehaviour
{
    [SerializeField] private InventoryItem _inventoryItem;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GameLoop.Instance.Player.Inventory.AddItem(_inventoryItem);
            gameObject.SetActive(false);
        }
    }
}