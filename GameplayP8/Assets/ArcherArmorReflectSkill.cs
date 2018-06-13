using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherArmorReflectSkill : AbbilitySkill
{
    [SerializeField] private int BonusArmor;
    [SerializeField] private HealthManager myHp;
    [SerializeField] private GameObject obj;
    [SerializeField] private float duration;
    [SerializeField] private float percentageReflet;
    private float maxDuration;

    public override void Init(Vector3 position = default(Vector3))
    {
        //behaviour.stats.armor += BonusArmor;
        //behaviour.stats.totalArmor += BonusArmor;
        obj.transform.position = transform.position;
        myHp.DamageEvent += Reflect;
    }

    public void Reflect(float i, HealthManager enemyHp)
    {
        if (enemyHp == null)
        {
            Debug.LogError("VERGETEN ENEMY HP MEE TE GEVEN BIJ DMG EVENT");
            return;
        }

        float newDmg = i / 100 * percentageReflet;
        enemyHp.Damage(newDmg);
    }

    public override void Tick()
    {
        if (duration >= 0)
        {
            obj.transform.position = transform.position;// TO FIX
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                //behaviour.stats.armor -= BonusArmor;
                //behaviour.stats.totalArmor -= BonusArmor;
                obj.transform.position = Vector3.zero;
                myHp.DamageEvent -= Reflect;
            }
        }
    }

}
