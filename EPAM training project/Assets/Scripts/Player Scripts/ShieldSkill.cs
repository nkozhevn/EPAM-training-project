using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkill : MonoBehaviour
{
    [SerializeField] public string buttonKeyCode = "Q";
    [SerializeField] public SkillIcon shieldIcon;
    [SerializeField] private float activeTime = 5f;
    [SerializeField] public float reloadTime = 30f;
    [SerializeField] private GameObject shield;
    private bool _isActivated = false;

    public void Activate()
    {
        if(!_isActivated)
        {
            StartCoroutine(Reload());
        }
        
    }

    private IEnumerator Reload()
    {

        _isActivated = true;
        shieldIcon.Reload(reloadTime);
        Player.Instance.gameObject.tag = "ImmunePlayer";
        shield.SetActive(true);
        yield return new WaitForSeconds(activeTime);
        shield.SetActive(false);
        Player.Instance.gameObject.tag = "Player";
        yield return new WaitForSeconds(reloadTime - activeTime);
        _isActivated = false;
    }
}
