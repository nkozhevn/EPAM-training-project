using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeSkill : MonoBehaviour
{
    [SerializeField] public string buttonKeyCode = "X";
    [SerializeField] public SkillIcon granadeIcon;
    [SerializeField] private Rigidbody granadePrefab;
    [SerializeField] private float throwForce = 30;
    [SerializeField] public float reloadTime = 10f;
    private bool _isActivated = false;

    public void Activate()
    {
        if(!_isActivated)
        {
            var granade = Instantiate(granadePrefab, gameObject.transform.position, gameObject.transform.rotation);
            granade.AddForce(gameObject.transform.up * throwForce, ForceMode.Impulse);

            StartCoroutine(Reload());
        }
        
    }

    private IEnumerator Reload()
    {
        _isActivated = true;
        granadeIcon.Reload(reloadTime);
        yield return new WaitForSeconds(reloadTime);
        _isActivated = false;
    }
}
