using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroppedItem : MonoBehaviour
{
    [Header("OnStartWeapon")]
    [SerializeField] private Text DmgText;
    [SerializeField] private Text CurrentDmgText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text weaponNameText;
    [SerializeField] private Image rarityImage;
    [SerializeField] private Image classTypeImage;

    [Header("OnStartArmore")]
    [SerializeField] private Text armoreNameText;

    [Header("Stats")]
    public MeshFilter meshRenderer;
    public int level;
    public string setName;
    public float damage;
    public CharacterType classType;
    public Rarity rarity;

    private GameObject UIWeaponObject;
    private GameObject UIArmoreObject;

    [Header("MeshTypes")]
    [SerializeField] private Mesh bowMesh;
    [SerializeField] private GameObject swordMesh;
    [SerializeField] private GameObject offhandMesh;
    [SerializeField] private GameObject chestMesh;
    [SerializeField] private GameObject helmetMesh;
    [SerializeField] private GameObject bootMesh;

    private ArmoreStats armoreStats;
    private WeaponStats weaponStats;

    public void Init(Drops d)
    {
        if(d is WeaponStats)
        {
            weaponStats = (WeaponStats)d;
            meshRenderer.mesh = bowMesh;
            level = weaponStats.levelRequirment;
            setName = weaponStats.setName;
            damage = weaponStats.damage;
            classType = weaponStats.Class;
            rarity = weaponStats.rarity;
        }
        else if(d is ArmoreStats)
        {
            armoreStats = (ArmoreStats)d;
        }
    }

    public void OnMouseEnter()
    {
        if (weaponStats != null)
        {
            DmgText.text = CharacterBehaviour.currentWeaponStats.damage.ToString();
            UIWeaponObject.SetActive(true);
        }
        else if (armoreStats != null)
        {
            //armorePoints = CharacterBehaviour.currentArmoreStats.defence.ToString();
            UIArmoreObject.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        UIWeaponObject.SetActive(false);
        UIArmoreObject.SetActive(false);
    }
}
