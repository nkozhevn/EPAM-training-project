using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Create new weapon")]
public class WeaponStats : ScriptableObject
{
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float bulletForce = 40f;
    [SerializeField] private float coolDown = 0.1f;
    [SerializeField] private int maxAmmo = 40;
    [SerializeField] private float reloadTime = 1f;

    public Rigidbody BulletPrefab => bulletPrefab;
    public float BulletForce => bulletForce;
    public float CoolDown => coolDown;
    public int MaxAmmo => maxAmmo;
    public float ReloadTime => reloadTime;
}
