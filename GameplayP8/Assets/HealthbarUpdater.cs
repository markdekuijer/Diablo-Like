using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthbarUpdater : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private HealthManager hpManager;
    [SerializeField] private TextMeshPro healthText;

    void Update ()
    {
        slider.value = (hpManager.GetCurrentHp / hpManager.GetMaxHp);
        healthText.text = Mathf.RoundToInt(hpManager.GetCurrentHp).ToString() + " / " + Mathf.RoundToInt(hpManager.GetMaxHp).ToString();
        if (hpManager.GetCurrentHp <= 0)
            gameObject.SetActive(false);
	}
}
