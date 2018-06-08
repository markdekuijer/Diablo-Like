using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSplitAttack : BasicAASkill
{
    public GameObject prefab;
    public float projectileSpeed;
    public float damage;
    public float spread;
    public int projectileAmount;

    public override void Execute(Vector3 targetPos = default(Vector3))
    {

        for (int i = 0; i < 15; i++)
        {
            GameObject arrow = Instantiate<GameObject>(prefab, transform.position + new Vector3(0,0.5f,0), Quaternion.Euler(0, targetPos.y + (-7 + i), 0));
            arrow.GetComponent<ProjectileMovement>().Init(this, targetPos, projectileSpeed, -7 + i);
        }
    }

    public override void DealDamage(HealthManager manager)
    {
        if(manager != null)
        {
            manager.TakeDamage(damage);
        }
    }
}

