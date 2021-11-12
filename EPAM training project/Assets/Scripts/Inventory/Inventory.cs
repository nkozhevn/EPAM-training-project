using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private PlayerShooting _playerShooting;
    [SerializeField] private SkillActivator _skillActivator;

    private List<IInventoryItem> _items = new List<IInventoryItem>();

    private List<IInventoryItem> _loadedItems = new List<IInventoryItem>();

    private void Start()
    {
        //foreach (var item in _loadedItems)
        //{
        //    AddItem(item);
        //}
    }

    public void AddItem(IInventoryItem item)
    {
        _items.Add(item);

        switch (item.Type)
        {
            case ItemType.Weapon:
                _playerShooting.AddWeaponByName(item.Name);
                break;
            case ItemType.Skill:
                _skillActivator.AddSkillByName(item.Name);
                break;
            default:
                throw new ArgumentException("Invalid item type.");
        }
    }
}

public interface IInventoryItem
{
    public string Name { get; }
    public ItemType Type { get; }
}

public enum ItemType
{
    Weapon,
    Skill
}