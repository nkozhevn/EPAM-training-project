using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeFinder : MonoBehaviour
{
    [SerializeField] public string upgradeName;
    [SerializeField] private Upgrade skillUpgrade;
    [SerializeField] private Image skillIcon;
    [SerializeField] public bool skillGot = false;

    private void Start() 
    {
        //if(PlayerPrefs.GetInt(upgradeName, 0) == 1)
        if(GameLoop.Instance.GameData.skills[upgradeName] == true)
        {
            skillGot = true;
        }
        else
        {
            skillIcon.enabled = false;
            skillGot = false;
        }
    }

    private void Update()
    {
        if(skillUpgrade.IsActivated)
        {
            skillGot = true;
            skillIcon.enabled = true;
        }
    }
}
