using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;

public abstract class Weapon : MonoBehaviour
{
    public event Action AmmoChanged;
    [SerializeField] protected WeaponStats weaponStats;
    private SkillIcon weaponIcon;
    [HideInInspector] private Image weaponIconBorder;
    [SerializeField] private InventoryItem inventoryItem;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AudioSource shootingAudio;

    private int _onShootHash;
    private float _shootingTimer = 99999f;
    private int _currentAmmo = 0;
    public bool OnShoot;
    private Animation _animation;
    private bool _isPicked;

    public bool IsReloading{ get; private set; }
    public bool IsPicked
    { 
        get => _isPicked;
        set
        {
            _isPicked = value;
            Initialize();
            weaponIcon.gameObject.SetActive(_isPicked);
        }
    }
    public int CurrentAmmo
    {
        get => _currentAmmo;
        set
        {
            _currentAmmo = value;
            AmmoChanged?.Invoke();
        }
    }
    public WeaponStats Stats => weaponStats;
    public InventoryItem InventoryItem => inventoryItem;

    private void Initialize()
    {
        weaponIcon = LevelController.Instance.UIController.AmmoUI.ItemIcons.First(x => x.ItemName == inventoryItem.Name);
    }

    private void Start()
    {
        CurrentAmmo = weaponStats.MaxAmmo;
        _animation = transform.GetComponent<Animation>();
        _onShootHash = Animator.StringToHash("onShoot");
    }

    private void OnEnable()
    {
        IsReloading = false;
        OnShoot = false;

        if(weaponIconBorder != null)
        {
            weaponIconBorder.enabled = true;
        }
    }

    private void Update()
    {
        if(OnShoot && _shootingTimer >= Stats.CoolDown)
        {
            if(IsReloading)
            {
                return;
            }
            if(CurrentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }

            Shoot();
            playerAnimator.SetTrigger(_onShootHash);
            shootingAudio.Play();

            _shootingTimer = 0;
        }
        else if(_shootingTimer < Stats.CoolDown)
        {
            _shootingTimer += Time.deltaTime;
            playerAnimator.ResetTrigger(_onShootHash);
        }
    }

    private void OnDisable()
    {
        if(weaponIconBorder != null)
        {
            weaponIconBorder.enabled = false;
        }
    }

    public abstract void Shoot();

    public IEnumerator Reload()
    {
        IsReloading = true;
        weaponIcon.Reload(weaponStats.ReloadTime);
        _animation.Play();
        yield return new WaitForSeconds(weaponStats.ReloadTime);
        CurrentAmmo = weaponStats.MaxAmmo;
        IsReloading = false;
    }

    public float AmmoPercent => (float)CurrentAmmo / weaponStats.MaxAmmo;
}
