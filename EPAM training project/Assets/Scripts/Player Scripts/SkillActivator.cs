using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActivator : MonoBehaviour
{
    [SerializeField] private UpgradeFinder granadeUpgradeFinder;
    [SerializeField] private GranadeSkill granadeSkill;

    private void Update()
    {
        if(granadeUpgradeFinder.skillGot)
        {
            if(Input.GetButtonDown(granadeSkill.buttonKeyCode))
            {
                granadeSkill.Activate();
            }
        }
    }
}
