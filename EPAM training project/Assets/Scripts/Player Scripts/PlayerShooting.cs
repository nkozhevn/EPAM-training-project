using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShooting : MonoBehaviour
{
    public event Action<Weapon> WeaponChanged;
    private int _selectedWeaponIndex = 0;
    private Weapon _selectedWeapon;
    private int _previousSelectedWeaponIndex;
    [SerializeField] public List<Weapon> weapons;
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

    private void Awake()
    {
        SelectWeapon();
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

            if(pressed)
            {
                _selectedWeaponIndex = keyMap[key];
            }
        }

        if(_previousSelectedWeaponIndex != _selectedWeaponIndex)
        {
            SelectWeapon();
        }

        if(Input.GetKeyDown(KeyCode.R) && _selectedWeapon.IsReloading == false)
        {
            StartCoroutine(_selectedWeapon.Reload());
        }
    }

    private void SelectWeapon()
    {
        for(var i = 0; i < weapons.Count; i++)
        {
            weapons[i].gameObject.SetActive(i == _selectedWeaponIndex);
        }
        _selectedWeapon = weapons[_selectedWeaponIndex];
        WeaponChanged?.Invoke(_selectedWeapon);
    }
}
