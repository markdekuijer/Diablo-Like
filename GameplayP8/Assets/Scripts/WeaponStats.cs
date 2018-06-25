using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Stats/Weapon")]
public class WeaponStats : ScriptableObject
{
    public string setName;
    public float damage;
    public int levelRequirment;
    public Rarity rarity;
    public CharacterType Class;
}

public enum Rarity
{
    common,
    rare,
    legendary
}

public enum CharacterType
{
    ranged,
    melee
}

