using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Running Enemy", menuName = "Enemies/Create new running enemy")]
public class RunningEnemyStats : ScriptableObject
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private int enemyPower = 3;
    [SerializeField] private float stunTime = 3f;

    public float MoveSpeed => moveSpeed;
    public int EnemyPower => enemyPower;
    public float StunTime => stunTime;
}
