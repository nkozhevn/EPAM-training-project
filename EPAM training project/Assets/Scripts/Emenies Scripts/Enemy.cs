using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Health health;
    [SerializeField] protected int levelPoints;
    [SerializeField] protected Animator animator;
    [SerializeField] protected GameObject deathEffect;
    [SerializeField] protected float effectLifeTime;

    protected Rigidbody _rb;
    protected NavMeshAgent navMeshAgent;
    protected Vector3 Direction { get; set; }
    protected Vector3 DirectionNorm { get; set; }
    protected Rigidbody Rigidbody => _rb;
}
