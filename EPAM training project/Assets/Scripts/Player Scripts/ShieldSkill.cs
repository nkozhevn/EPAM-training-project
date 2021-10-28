using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ISkill
{
    void Activate();
}

public abstract class Skill : MonoBehaviour, ISkill
{
    [SerializeField] public string buttonKeyCode = "Q";
    [SerializeField] public SkillIcon shieldIcon;

    public abstract void Activate();
    protected abstract IEnumerator Reload();
}


public class ShieldSkill : Skill
{
    [SerializeField] private float activeTime = 5f;
    [SerializeField] public float reloadTime = 30f;
    [SerializeField] private GameObject shield;
    private bool _isActivated = false;

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
        shieldIcon.Reload(reloadTime);
        Player.Instance.Health.ToggleInvulnerability(true);
        shield.SetActive(true);
        yield return new WaitForSeconds(activeTime);
        shield.SetActive(false);
        Player.Instance.Health.ToggleInvulnerability(false);
        yield return new WaitForSeconds(reloadTime - activeTime);
        _isActivated = false;
    }
}
