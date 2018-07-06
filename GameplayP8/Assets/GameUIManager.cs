using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private HealthManager hpManager;
    [SerializeField] private Image hpBar;
    [SerializeField] private Image glow;

    [SerializeField] private GameObject basicAttacksMenu;
    [SerializeField] private GameObject abbilityMenu;
    [SerializeField] private GameObject presets;

    public static bool Paused;

    public void Init()
    {
        hpBar.fillAmount = hpManager.GetMaxHp / hpManager.GetCurrentHp;
        hpManager.DamageEvent += UpdateHealth;
    }

    public void UpdateHealth(float f, HealthManager h, GameObject g)
    {
        hpBar.fillAmount = hpManager.GetCurrentHp / hpManager.GetMaxHp;
        if (hpManager.GetCurrentHp <= 0)
            glow.gameObject.SetActive(false);
    }

    public void SwitchMenuSkillPreset()
    {
        abbilityMenu.SetActive(!abbilityMenu.activeSelf);
        basicAttacksMenu.SetActive(!basicAttacksMenu.activeSelf);
    }

    public void OpenPresets()
    {
        Paused = true;
        presets.SetActive(true);
        basicAttacksMenu.SetActive(true);
        abbilityMenu.SetActive(false);
    }

    public void ExitPresets()
    {
        Paused = false;
        presets.SetActive(false);
    }
}
