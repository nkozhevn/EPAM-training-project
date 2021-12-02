using System.Collections;
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
        skillIcon.Reload(reloadTime);
        LevelController.Instance.Player.Health.ToggleInvulnerability(true);
        shield.SetActive(true);
        yield return new WaitForSeconds(activeTime);
        shield.SetActive(false);
        LevelController.Instance.Player.Health.ToggleInvulnerability(false);
        yield return new WaitForSeconds(reloadTime - activeTime);
        _isActivated = false;
    }
}
