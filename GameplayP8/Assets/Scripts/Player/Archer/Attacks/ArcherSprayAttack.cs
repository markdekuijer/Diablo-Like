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

    public override void Execute(GameObject target = null)
    {

        for (int i = 0; i < 15; i++)
        {
            GameObject arrow = Instantiate<GameObject>(prefab, transform.position + new Vector3(0,0.5f,0), Quaternion.Euler(0, target.transform.position.y + (-7 + i), 0));
            arrow.GetComponent<ProjectileMovement>().Init(this, target.transform.position, projectileSpeed, -7 + i);
        }
    }

    public override void DealDamage(HealthManager manager,GameObject projectile)
    {
        if(manager != null)
        {
            manager.Damage(damage, null, gameObject);
        }
        projectile.SetActive(false);
    }
}

