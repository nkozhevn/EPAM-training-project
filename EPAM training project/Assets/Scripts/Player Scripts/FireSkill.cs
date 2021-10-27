using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : MonoBehaviour
{
    [SerializeField] public string buttonKeyCode = "Z";
    [SerializeField] public SkillIcon fireIcon;
    [SerializeField] private Rigidbody firePrefab;
    [SerializeField] private float throwForce = 50;
    [SerializeField] public float reloadTime = 15f;
    [SerializeField] private float timeToDestroy = 10f;
    private bool _isActivated = false;

    public void Activate()
    {
        if(!_isActivated)
        {
            var granade = Instantiate(firePrefab, gameObject.transform.position, gameObject.transform.rotation);
            granade.AddForce(gameObject.transform.up * throwForce, ForceMode.Impulse);

            Destroy(granade, timeToDestroy);

            StartCoroutine(Reload());
        }
        
    }

    private IEnumerator Reload()
    {
        _isActivated = true;
        fireIcon.Reload(reloadTime);
        yield return new WaitForSeconds(reloadTime);
        _isActivated = false;
    }
}
