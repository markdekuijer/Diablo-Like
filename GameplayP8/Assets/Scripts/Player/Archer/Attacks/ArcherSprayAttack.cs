using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSprayAttack : BasicAASkill
{
    public GameObject prefab;
    public float projectileSpeed;
    public float damage;
    public float spread;
    public int projectileAmount;

    private float realDmg;

    public override void Execute(CharacterBehaviour behaviour, GameObject target = null)
    {
        realDmg = behaviour.CalculateAADamage(damage);
        for (int i = 0; i < 15; i++)
        {
            GameObject arrow = ObjectPooler.SharedInstance.GetPooledObject(1);
            arrow.SetActive(true);
            arrow.transform.position = transform.position + new Vector3(0, 0.5f, 0);
            arrow.transform.rotation = Quaternion.Euler(0, target.transform.position.y + (-7 + i), 0);
            arrow.GetComponent<ProjectileMovement>().Init(this, target.transform.position, projectileSpeed, -7 + i);
        }
    }

    public override void DealDamage(HealthManager manager,GameObject projectile)
    {
        if(manager != null)
        {
            manager.Damage(realDmg, null, gameObject);
        }
        projectile.SetActive(false);
    }
}

