using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private Animation animation;

    private void Start()
    {
        animation = transform.GetComponent<Animation>();
    }

    public void DamageEffect()
    {
        animation.Play();
    }
}
