using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3D : MonoBehaviour
{
    [SerializeField]
    private GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            return;
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.25f);
        Destroy(gameObject);
    }
}
