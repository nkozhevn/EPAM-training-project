using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    public string Name { get; }
    public ItemType Type { get; }
}
