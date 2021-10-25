using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActivator : MonoBehaviour
{
    [SerializeField] private UpgradesFinder upgradesFinder;
    [SerializeField] private GranadeSkill granadeSkill;

    private void Update()
    {
        if(upgradesFinder.granadeGot)
        {
            if(Input.GetButtonDown(granadeSkill.buttonKeyCode))
            {
                granadeSkill.Activate();
            }
        }
    }
}
