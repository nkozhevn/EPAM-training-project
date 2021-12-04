using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public abstract class Skill : MonoBehaviour, ISkill
{
    [SerializeField] public string buttonKeyCode = "Q";
    [HideInInspector] public SkillIcon skillIcon;
    [SerializeField] public float reloadTime = 30f;
    [SerializeField] private InventoryItem inventoryItem;

    protected bool _isActivated = false;
    private bool _isPicked;

    private void Awake()
    {
        LevelController.Instance.GameInitialized += Initialized;
    }

    private void Initialized()
    {
        skillIcon = LevelController.Instance.UIController.AmmoUI.ItemIcons.First(x => x.ItemName == inventoryItem.Name);
    }

    private void OnDestroy()
    {
        LevelController.Instance.GameInitialized -= Initialized;
    }

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
