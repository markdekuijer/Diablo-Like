using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArmoreStats", menuName = "Stats/Armore")]
public class ArmoreStats : ScriptableObject
{
    public string setName;
    public float armore;
    public float movementSpeedBoost;
    public int LevelRequiredment;
    public Rarity rarity;
}
