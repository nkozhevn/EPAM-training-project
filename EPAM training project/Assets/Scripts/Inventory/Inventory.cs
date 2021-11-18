using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private PlayerShooting _playerShooting;
    [SerializeField] private SkillActivator _skillActivator;

    private List<InventoryItem> _items = new List<InventoryItem>();

    public bool GotCheck(string itemName)
    {
        if(_items.Exists(item => item.Name == itemName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddItem(InventoryItem item)
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
