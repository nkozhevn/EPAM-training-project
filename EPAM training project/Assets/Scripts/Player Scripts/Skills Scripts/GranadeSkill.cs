using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeSkill : Skill
{
    [SerializeField] private Rigidbody granadePrefab;
    [SerializeField] private float throwForce = 30;

    public override void Activate()
    {
        if(!_isActivated)
        {
            var granade = Instantiate(granadePrefab, gameObject.transform.position, gameObject.transform.rotation);
            Rigidbody rb = granade.GetComponent<Rigidbody>();
            rb.AddForce(gameObject.transform.up * throwForce, ForceMode.Impulse);

            StartCoroutine(Reload());
        }
        
    }

    protected override IEnumerator Reload()
    {
        _isActivated = true;
        skillIcon.Reload(reloadTime);
        yield return new WaitForSeconds(reloadTime);
        _isActivated = false;
    }
}
