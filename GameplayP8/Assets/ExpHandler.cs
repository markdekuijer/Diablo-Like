using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpHandler : MonoBehaviour
{
    public static ExpHandler Instance { get { return instance; } }
    private static ExpHandler instance;

    [SerializeField] private Image expImage;
    [SerializeField] private int maxLevel;

    private int currentExp;
    private int currentLevel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentLevel = CharacterBehaviour.characterStats.associatedLevel;
    }

    public void GiveExp(int earnedExp)
    {
        currentExp += earnedExp;
        if(currentExp >= CharacterBehaviour.characterStats.xpNeeded)
        {
            if (currentLevel >= maxLevel)
            {
                currentExp = (int)CharacterBehaviour.characterStats.xpNeeded;
                expImage.fillAmount = 1;
                return;
            }
            int neededExp = currentExp - (int)CharacterBehaviour.characterStats.xpNeeded;
            currentLevel++;
            CharacterBehaviour.characterStats = Resources.Load<CharStats>("ScriptableStuff/CharacterStats/ArcherLevel" + currentLevel.ToString());
            currentExp = neededExp;
        }

        if (currentExp == 0)
            expImage.fillAmount = 0;
        else
            expImage.fillAmount = currentExp / CharacterBehaviour.characterStats.xpNeeded;
    }
}
