using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Create new item")]

public class InventoryItem : ScriptableObject, IInventoryItem
{
    [SerializeField] private string name;
    [SerializeField] private ItemType type;

    public string Name => name;
    public ItemType Type => type;

}
