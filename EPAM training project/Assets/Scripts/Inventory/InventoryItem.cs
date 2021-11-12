using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Create new item")]

public class InventoryItem : ScriptableObject, IInventoryItem
{
    [SerializeField] private string name;
    [SerializeField] private ItemType type;
    [SerializeField] private Sprite icon;

    public string Name => name;
    public ItemType Type => type;
    public Sprite Icon => icon;

}