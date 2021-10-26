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
        if(PlayerPrefs.GetInt(upgradeName, 0) == 0)
        {
            skillIcon.enabled = false;
            skillGot = false;
        }
        else
        {
            skillGot = true;
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
