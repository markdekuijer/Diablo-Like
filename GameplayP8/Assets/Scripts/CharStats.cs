using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LevelStats", menuName = "Stats/Characters")]
public class CharStats : ScriptableObject
{
    public int associatedLevel;

    public float armore;
    public float health;
    public float baseDamage;
    public float xpNeeded;
}
