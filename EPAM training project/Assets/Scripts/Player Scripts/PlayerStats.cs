using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private int maxLevelPoints = 10;

    public float MoveSpeed => moveSpeed;
    public float TurnSpeed => turnSpeed;
    public int MaxLevelPoints => maxLevelPoints;
}
