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

    protected override void Start()
    {
        base.Start();
        maxDuration = duration;
    }

    public override void Init(Vector3 position = default(Vector3))
    {
        if (GetCooldownProcent() > 0)
            return;

        cooldown = maxCooldown;
        //behaviour.stats.armor += BonusArmor;
        //behaviour.stats.totalArmor += BonusArmor;
        obj.transform.position = transform.position;
        myHp.DamageEvent += Reflect;
        duration = maxDuration;
    }

    public void Reflect(float i, HealthManager enemyHp, GameObject g = null)
    {
        if (enemyHp == null)
        {
            return;
        }

        float newDmg = i / 100 * percentageReflet;
        enemyHp.Damage(newDmg , null, gameObject);
    }

    public override void Tick()
    {
        cooldown -= Time.deltaTime;

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
