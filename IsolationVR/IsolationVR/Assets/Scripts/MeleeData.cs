using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Melee Data")]
public class MeleeData : ScriptableObject
{
    [Header("Weapon Info")]
    public string weaponName;
    public string weaponRarity;

    [Header("Weapon Stats")]
    public float damage;
}
