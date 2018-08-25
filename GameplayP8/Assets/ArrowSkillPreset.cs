using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArrowSkillPreset : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private TextMeshProUGUI buttoText;
    [SerializeField] private Button button;
    [SerializeField] private Sprite image;

    [Header("skills")]
    [SerializeField] private CharacterAttack character;
    [SerializeField] private AbbilitySkill abbilitySkill;
    [SerializeField] private BasicAASkill basicAASkill;
    [SerializeField] private DisplayCouldown couldown;

    [SerializeField] private List<DisplayCouldown> displayers = new List<DisplayCouldown>();

    public bool autoEquip;

    private bool equiped;

    private void Awake()
    {
        if (autoEquip)
            Equip();
    }

    public void Equip()
    {
        if (equiped)
        {
            Unequip();
            return;
        }

        if (basicAASkill != null)
        {
            for (int i = 0; i < character.basicAttacks.Length; i++)
            {
                if (character.basicAttacks[i] == null)
                {
                    character.basicAttacks[i] = basicAASkill;
                    displayers[i].SetImage(image);
                    displayers[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    buttoText.text = "Unequip";
                    equiped = true;
                    break;
                }
            }
        }
        else if(abbilitySkill != null)
        {
            for (int i = 0; i < character.abbilityAttacks.Length; i++)
            {
                if (character.abbilityAttacks[i] == null)
                {
                    character.abbilityAttacks[i] = abbilitySkill;
                    displayers[i].SetImage(image);
                    displayers[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    buttoText.text = "Unequip";
                    equiped = true;
                    break;
                }
            }
        }
    }

    public void Unequip()
    {
        //couldown.SetImage(image);
        if (basicAASkill != null)
        {
            for (int i = 0; i < character.basicAttacks.Length; i++)
            {
                if (character.basicAttacks[i] == basicAASkill)
                {
                    character.basicAttacks[i] = null;
                    displayers[i].SetImage(null);
                    displayers[i].GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    buttoText.text = "Equip";
                    equiped = false;
                    break;
                }
            }
        }
        else if (abbilitySkill != null)
        {
            for (int i = 0; i < character.abbilityAttacks.Length; i++)
            {
                if (character.abbilityAttacks[i] == abbilitySkill)
                {
                    character.abbilityAttacks[i] = null;
                    displayers[i].SetImage(null);
                    displayers[i].GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    buttoText.text = "Equip";
                    equiped = false;
                    break;
                }
            }
        }
    }
}
