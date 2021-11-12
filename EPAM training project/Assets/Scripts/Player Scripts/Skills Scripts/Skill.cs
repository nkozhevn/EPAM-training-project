using System.Collections;
using UnityEngine;

public abstract class Skill : MonoBehaviour, ISkill
{
    [SerializeField] public string buttonKeyCode = "Q";
    [SerializeField] public SkillIcon icon;
    [SerializeField] public float reloadTime = 30f;
    [SerializeField] private InventoryItem inventoryItem;

    protected bool _isActivated = false;

    public bool IsPicked { get; set; }
    public InventoryItem InventoryItem => inventoryItem;

    public abstract void Activate();
    protected abstract IEnumerator Reload();
}
