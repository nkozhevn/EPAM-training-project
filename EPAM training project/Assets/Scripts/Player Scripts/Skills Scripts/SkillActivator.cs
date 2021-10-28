using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActivator : MonoBehaviour
{
    [SerializeField] private List<Skill> skills;
    [SerializeField] private List<UpgradeFinder> upgrades;

    private void Update()
    {
        for(int i = 0; i < skills.Count; i++)
        {
            if(upgrades[i].skillGot)
            {
                if(Input.GetButtonDown(skills[i].buttonKeyCode))
                {
                    skills[i].Activate();
                }
            }
        }
    }
}
