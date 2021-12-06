using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class PlayerShooting : MonoBehaviour
{
    public event Action<Weapon> WeaponChanged;
    [SerializeField] private List<Weapon> weapons;
    private int _selectedWeaponIndex = 0;
    private Weapon _selectedWeapon;
    private int _previousSelectedWeaponIndex;

    private readonly Dictionary<KeyCode, int> keyMap = new Dictionary<KeyCode, int>
    {
        {KeyCode.Alpha1, 0},
        {KeyCode.Alpha2, 1},
        {KeyCode.Alpha3, 2},
        {KeyCode.Alpha4, 3},
        {KeyCode.Alpha5, 4},
        {KeyCode.Alpha6, 5},
        {KeyCode.Alpha7, 6},
        {KeyCode.Alpha8, 7},
        {KeyCode.Alpha9, 8}
    };

    public Weapon SelectedWeapon => _selectedWeapon;
    public int SelectedWeaponIndex => _selectedWeaponIndex;
    private List<Weapon> _pickedWeapons => weapons.Where(x => x.IsPicked).ToList();

    private void Awake()
    {
        LevelController.Instance.GameInitialized += Initialized;
    }

    private void Initialized()
    {
        var defaultWeapon = weapons.First();
        if (!defaultWeapon.gameObject.activeInHierarchy)
        {
            defaultWeapon.gameObject.SetActive(true);
        }
        defaultWeapon.IsPicked = true;
        
        SelectWeapon(_selectedWeaponIndex);
    }

    private void Update()
    {
        _previousSelectedWeaponIndex = _selectedWeaponIndex;

        if(Input.GetButtonDown("Fire1"))
        {
            _selectedWeapon.OnShoot = true;
        }
        if(Input.GetButtonUp("Fire1"))
        {
            _selectedWeapon.OnShoot = false;
        }

        foreach(var key in keyMap.Keys)
        {
            var pressed = Input.GetKey(key);

            if(pressed && keyMap[key] < _pickedWeapons.Count)
            {
                _selectedWeaponIndex = keyMap[key];
            }
        }

        if(_previousSelectedWeaponIndex != _selectedWeaponIndex)
        {
            SelectWeapon(_selectedWeaponIndex);
        }

        if(Input.GetKeyDown(KeyCode.R) && _selectedWeapon.IsReloading == false)
        {
            StartCoroutine(_selectedWeapon.Reload());
        }
    }

    private void SelectWeapon(int selectedWeaponIndex)
    {
        for(int i = 0; i < _pickedWeapons.Count; i++)
        {
            _pickedWeapons[i].gameObject.SetActive(i == selectedWeaponIndex);
        }
        _selectedWeapon = _pickedWeapons[selectedWeaponIndex];
        WeaponChanged?.Invoke(_selectedWeapon);
    }

    public void AddWeaponByName(string name)
    {
        var weapon = weapons.First(x => x.InventoryItem.Name == name);
        weapon.IsPicked = true;
    }

    private void OnDestroy()
    {
        LevelController.Instance.GameInitialized -= Initialized;
    }
}
