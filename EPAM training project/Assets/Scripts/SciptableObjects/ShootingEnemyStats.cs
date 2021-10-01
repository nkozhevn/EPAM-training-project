using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shooting Enemy", menuName = "Enemies/Create new shooting enemy")]
public class ShootingEnemyStats : ScriptableObject
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float shootingDist = 50f;
    [SerializeField] private float shootingCoolDown = 0.5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 40f;

    public float MoveSpeed => moveSpeed;
    public float ShootingDist => shootingDist;
    public float ShootingCoolDown => shootingCoolDown;
    public GameObject BulletPrefab => bulletPrefab;
    public float BulletForce => bulletForce;
}
