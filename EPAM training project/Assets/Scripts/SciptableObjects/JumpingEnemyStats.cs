using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpingEnemyStats", menuName = "Enemies/Create new jumping enemy")]
public class JumpingEnemyStats : ScriptableObject 
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private int enemyPower = 3;
    [SerializeField] private float jumpingDist = 30f;
    [SerializeField] private float jumpingWaitTime = 1f;
    [SerializeField] private float jumpingCoolDown = 3f;
    [SerializeField] private float jumpForce = 40f;

    public float MoveSpeed => moveSpeed;
    public int EnemyPower => enemyPower;
    public float JumpingDist => jumpingDist;
    public float JumpingWaitTime => jumpingWaitTime;
    public float JumpingCoolDown => jumpingCoolDown;
    public float JumpForce => jumpForce;
}
