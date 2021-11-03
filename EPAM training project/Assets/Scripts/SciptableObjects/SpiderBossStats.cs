using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spider Boss Enemy", menuName = "Enemies/Create new spider boss enemy")]
public class SpiderBossStats : ScriptableObject
{
    [SerializeField] private float moveSpeed = 17f;
    [SerializeField] private int enemyPower = 50;
    [SerializeField] private float activationDist = 50f;
    [SerializeField] private float shootingCoolDown = 0.1f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 70f;
    [SerializeField] private float shootingWaitTime = 2f;
    [SerializeField] private float shootingActiveTime = 5f;
    [SerializeField] private float shootingReloadTime = 1f;
    [SerializeField] private float launchingCoolDown = 1f;
    [SerializeField] private GameObject granadePrefab;
    [SerializeField] private float granadeForce = 30f;
    [SerializeField] private float launchingWaitTime = 3f;
    [SerializeField] private float launchingActiveTime = 5f;
    [SerializeField] private float launchingReloadTime = 2f;
    [SerializeField] private float dashSpeed = 30f;
    [SerializeField] private float dashWaitTime = 3f;
    [SerializeField] private float dashActiveTime = 10f;
    [SerializeField] private float dashReloadTime = 4f;

    public float MoveSpeed => moveSpeed;
    public int EnemyPower => enemyPower;
    public float ActivationDist => activationDist;
    public float ShootingCoolDown => shootingCoolDown;
    public GameObject BulletPrefab => bulletPrefab;
    public float BulletForce => bulletForce;
    public float ShootingWaitTime => shootingWaitTime;
    public float ShootingActiveTime => shootingActiveTime;
    public float ShootingReloadTime => shootingReloadTime;
    public float LaunchingCoolDown => launchingCoolDown;
    public GameObject GranadePrefab => granadePrefab;
    public float GranadeForce => granadeForce;
    public float LaunchingWaitTime => launchingWaitTime;
    public float LaunchingActiveTime => launchingActiveTime;
    public float LaunchingReloadTime => launchingReloadTime;
    public float DashSpeed => dashSpeed;
    public float DashWaitTime => dashWaitTime;
    public float DashActiveTime => dashActiveTime;
    public float DashReloadTime => dashReloadTime;
}
