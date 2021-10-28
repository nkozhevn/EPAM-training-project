using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour, ISkill
{
    [SerializeField] public string buttonKeyCode = "Q";
    [SerializeField] public SkillIcon icon;
    [SerializeField] public float reloadTime = 30f;
    protected bool _isActivated = false;

    public abstract void Activate();
    protected abstract IEnumerator Reload();
}
