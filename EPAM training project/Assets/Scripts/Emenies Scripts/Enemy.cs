using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Health health;
    protected Rigidbody _rb;
    [SerializeField] protected int levelPoints;
    protected Vector3 Direction { get; set; }
    protected Vector3 DirectionNorm { get; set; }
    protected Rigidbody Rigidbody => _rb;
}
