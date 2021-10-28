using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkill : Skill
{
    [SerializeField] private float activeTime = 5f;
    [SerializeField] private GameObject shield;

    public override void Activate()
    {
        if(!_isActivated)
        {
            StartCoroutine(Reload());
        }
        
    }

    protected override IEnumerator Reload()
    {

        _isActivated = true;
        icon.Reload(reloadTime);
        Player.Instance.gameObject.tag = "ImmunePlayer";
        shield.SetActive(true);
        yield return new WaitForSeconds(activeTime);
        shield.SetActive(false);
        Player.Instance.gameObject.tag = "Player";
        yield return new WaitForSeconds(reloadTime - activeTime);
        _isActivated = false;
    }
}
