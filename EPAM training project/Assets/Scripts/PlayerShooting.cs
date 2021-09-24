using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private float _shootingTimer = 99999f;
    [SerializeField] private int selectedWeapon = 0;
    private Shooting _shooting;
    private int _previousSelectedWeapon;

    private void Start()
    {
        SelectWeapon();
    }

    private void Update()
    {
        _previousSelectedWeapon = selectedWeapon;

        if(Input.GetButton("Fire1") && _shootingTimer >= _shooting.coolDown)
        {
            _shooting.Shoot();
            _shootingTimer = 0;
        }
        else if(_shootingTimer < _shooting.coolDown)
        {
            _shootingTimer += Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
        {
            selectedWeapon = 4;
        }
        if(Input.GetKeyDown(KeyCode.Alpha6) && transform.childCount >= 6)
        {
            selectedWeapon = 5;
        }
        if(Input.GetKeyDown(KeyCode.Alpha7) && transform.childCount >= 7)
        {
            selectedWeapon = 6;
        }
        if(Input.GetKeyDown(KeyCode.Alpha8) && transform.childCount >= 8)
        {
            selectedWeapon = 7;
        }
        if(Input.GetKeyDown(KeyCode.Alpha9) && transform.childCount >= 9)
        {
            selectedWeapon = 8;
        }

        if(_previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

        if(Input.GetKeyDown(KeyCode.R) && _shooting.isReloading == false)
        {
            StartCoroutine(_shooting.Reload());
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                _shooting = weapon.GetComponent<Shooting>();
            }
            else if(i == _previousSelectedWeapon)
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
