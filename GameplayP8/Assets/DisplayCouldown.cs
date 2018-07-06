using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCouldown : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private bool isBasicAttack;
    [SerializeField] private CharacterAttack characterAttack;
    [SerializeField] private int skillIndex;
    [SerializeField] private Image displayImage;
    [SerializeField] private TextMeshProUGUI text;

	void Start ()
    {
		
	}

    public void SetImage(Sprite s)
    {
        displayImage.sprite = s;
    }

	void Update ()
    {
        if (isBasicAttack)
        {
            image.fillAmount = characterAttack.GetAttackspeedAmount();
            if (characterAttack.GetAttackspeedAmount() > 0)
                text.text = Mathf.RoundToInt(characterAttack.GetAttackspeedAmount()).ToString();
            else
                text.text = "";
        }
        else if (characterAttack.abbilityAttacks[skillIndex] != null)
        {
            image.fillAmount = characterAttack.abbilityAttacks[skillIndex].GetCooldownProcent();
            if (characterAttack.abbilityAttacks[skillIndex].GetCooldown() > 0)
                text.text = Mathf.RoundToInt(characterAttack.abbilityAttacks[skillIndex].GetCooldown()).ToString();
            else
                text.text = "";
        }
        else
        {
            image.fillAmount = 1;
            text.text = "";
            displayImage.sprite = null;
        }
    }
}
