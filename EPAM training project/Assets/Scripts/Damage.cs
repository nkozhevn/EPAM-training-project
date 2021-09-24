using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private Animation animation;
    [SerializeField] private int healthPoints = 3;
    private int hitCount;

    private void Awake()
    {
        hitCount = 0;
        animation = transform.GetComponent<Animation>();
    }

    public void DamageEffect(int x)
    {
        hitCount = hitCount + x;
        if(hitCount < healthPoints)
        {
            //animation.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
