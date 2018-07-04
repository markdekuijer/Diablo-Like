using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DroppedItem : MonoBehaviour
{
    [Header("OnStartWeapon")]
    [SerializeField] private TextMeshPro DmgText;
    [SerializeField] private TextMeshPro CurrentDmgText;
    [SerializeField] private TextMeshPro levelText;
    [SerializeField] private TextMeshPro weaponNameText;
    [SerializeField] private TextMeshPro classTypeText;
    [SerializeField] private TextMeshPro rarityText;
    [SerializeField] private Image rarityImage;

    [Header("OnStartArmore")]
    [SerializeField] private TextMeshPro armoreNameText;

    [Header("OnStartOther")]
    [SerializeField] private GameObject UIWeaponObject;
    [SerializeField] private GameObject UIArmoreObject;
    [SerializeField] private MeshFilter meshRenderer;
    [SerializeField] private Rigidbody rb;

    [Header("Stats")]
    public int level;
    public string setName;
    public float damage;
    public CharacterType classType;
    public Rarity rarity;


    [Header("MeshTypes")]
    [SerializeField] private Mesh bowMesh;
    [SerializeField] private Mesh swordMesh;
    [SerializeField] private Mesh offhandMesh;
    [SerializeField] private Mesh chestMesh;
    [SerializeField] private Mesh helmetMesh;
    [SerializeField] private Mesh bootMesh;

    private ArmoreStats armoreStats;
    private WeaponStats weaponStats;

    public void Init(Drops d)
    {
        armoreStats = null;
        weaponStats = null;

        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(Random.Range(-1, 1), Random.Range(0, 1), Random.Range(-1, 1)));

        if(d is WeaponStats)
        {
            print("Weapon");
            weaponStats = (WeaponStats)d;
            meshRenderer.mesh = bowMesh;
            levelText.text = (level = weaponStats.levelRequirment).ToString();
            weaponNameText.text = setName = weaponStats.setName;
            DmgText.text = (damage = weaponStats.damage).ToString();
            classTypeText.text = (classType = weaponStats.Class).ToString();
            rarity = weaponStats.rarity;
            if (rarity == Rarity.common)
            {
                rarityText.text = "Common";
                rarityImage.color = Color.gray;
            }
            else if (rarity == Rarity.rare)
            {
                rarityText.text = "Rare";
                rarityImage.color = Color.cyan;
            }
            else if (rarity == Rarity.legendary)
            {
                rarityText.text = "Legendary";
                rarityImage.color = Color.yellow;
            }
        }
        else if(d is ArmoreStats)
        {
            print("Armore");
            armoreStats = (ArmoreStats)d;
        }
        else
        {
            print("haal levi");
        }
    }

    public void OnMouseEnter()
    {
        if (weaponStats != null)
        {
            CurrentDmgText.text = CharacterBehaviour.currentWeaponStats.damage.ToString();
            UIWeaponObject.SetActive(true);
        }
        else if (armoreStats != null)
        {
            //armorePoints = CharacterBehaviour.currentArmoreStats.defence.ToString();
            UIArmoreObject.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(CharacterBehaviour.currentPosition, transform.position) < 2)
        {
            if (weaponStats != null)
                CharacterBehaviour.currentWeaponStats = weaponStats;
            else if (armoreStats != null)
                CharacterBehaviour.currentArmoreStats = armoreStats;

            gameObject.SetActive(false);
        }
    }

    public void OnMouseExit()
    {
        UIWeaponObject.SetActive(false);
        UIArmoreObject.SetActive(false);
    }
}
