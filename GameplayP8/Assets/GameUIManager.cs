using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private HealthManager hpManager;
    [SerializeField] private Image hpBar;
    [SerializeField] private Image glow;

    public void Init()
    {
        hpBar.fillAmount = hpManager.GetMaxHp / hpManager.GetCurrentHp;
        print(hpManager.GetMaxHp + "    |    " + hpManager.GetCurrentHp);
        hpManager.DamageEvent += UpdateHealth;
    }

    public void UpdateHealth(float f, HealthManager h, GameObject g)
    {
        hpBar.fillAmount = hpManager.GetCurrentHp / hpManager.GetMaxHp;
        if (hpManager.GetCurrentHp <= 0)
            glow.gameObject.SetActive(false);

        print(hpManager.GetMaxHp + "    |    " + hpManager.GetCurrentHp);

    }
}
