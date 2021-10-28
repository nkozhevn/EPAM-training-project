using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActivator : MonoBehaviour
{
    [SerializeField] private UpgradeFinder granadeUpgradeFinder;
    [SerializeField] private GranadeSkill granadeSkill;
    [SerializeField] private UpgradeFinder fireUpgradeFinder;
    [SerializeField] private FireSkill fireSkill;
    [SerializeField] private UpgradeFinder shieldUpgradeFinder;
    [SerializeField] private ShieldSkill shieldSkill;

    private void Update()
    {
        if(granadeUpgradeFinder.skillGot)
        {
            if(Input.GetButtonDown(granadeSkill.buttonKeyCode))
            {
                granadeSkill.Activate();
            }
        }

        if(fireUpgradeFinder.skillGot)
        {
            if(Input.GetButtonDown(fireSkill.buttonKeyCode))
            {
                fireSkill.Activate();
            }
        }

        if(shieldUpgradeFinder.skillGot)
        {
            if(Input.GetButtonDown(shieldSkill.buttonKeyCode))
            {
                shieldSkill.Activate();
            }
        }
    }
}
