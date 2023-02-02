using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun Data")]
public class GunData : ScriptableObject
{
    [Header("Weapon Info")]
    public string weaponName;
    public string weaponRarity;

    [Header("Weapon Stats")]
    public float damage;
    public float attackSpeed;
    public float reloadSpeed;
    public bool isAuto;
    public bool isHitscan;

    [Header("Bullet Stats")]
    public float bulletSpeed;
    public float maxBullets;
    public float bulletRange;
    public GameObject bulletPrefab;
}
