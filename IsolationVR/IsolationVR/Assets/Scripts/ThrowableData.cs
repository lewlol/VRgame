using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Throwable Data")]
public class ThrowableData : ScriptableObject
{
    [Header("Weapon Info")]
    public string weaponName;
    public string weaponRarity;

    [Header("Weapon Stats")]
    public float damage;
    public float speed;
}
