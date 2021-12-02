using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour, ISkill
{
    [SerializeField] public string buttonKeyCode = "Q";
    [SerializeField] public SkillIcon skillIcon;
    [SerializeField] private Image icon;
    [SerializeField] public float reloadTime = 30f;
    [SerializeField] private InventoryItem inventoryItem;

    protected bool _isActivated = false;
    private bool _isPicked;

    public bool IsPicked
    { 
        get => _isPicked;
        set
        {
            _isPicked = value;
            skillIcon.gameObject.SetActive(_isPicked);
        }
    }
    public InventoryItem InventoryItem => inventoryItem;

    public abstract void Activate();

    protected abstract IEnumerator Reload();
}
