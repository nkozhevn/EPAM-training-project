using System.Collections;
using System.Collections.Generic;
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
    public List<Weapon> Weapons => weapons;

    /*private void Start()
    {
        SelectWeapon(_selectedWeaponIndex);
    }*/

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

            if(pressed && keyMap[key] < weapons.Count)
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

    public void SelectWeapon(int selectedWeaponIndex)
    {
        for(int i = 0; i < weapons.Count; i++)
        {
            weapons[i].gameObject.SetActive(i == selectedWeaponIndex);
        }
        _selectedWeapon = weapons[selectedWeaponIndex];
        WeaponChanged?.Invoke(_selectedWeapon);
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }
}
