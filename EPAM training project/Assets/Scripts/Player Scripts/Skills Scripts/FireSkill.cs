using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : Skill
{
    [SerializeField] private Rigidbody firePrefab;
    [SerializeField] private float throwForce = 50;
    [SerializeField] private float timeToDestroy = 10f;

    public override void Activate()
    {
        if(!_isActivated)
        {
            var granade = Instantiate(firePrefab, gameObject.transform.position, gameObject.transform.rotation);
            granade.AddForce(gameObject.transform.up * throwForce, ForceMode.Impulse);

            Destroy(granade, timeToDestroy);

            StartCoroutine(Reload());
        }
        
    }

    protected override IEnumerator Reload()
    {
        _isActivated = true;
        icon.Reload(reloadTime);
        yield return new WaitForSeconds(reloadTime);
        _isActivated = false;
    }
}
