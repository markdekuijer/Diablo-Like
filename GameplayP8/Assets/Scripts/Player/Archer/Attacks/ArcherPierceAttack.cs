﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPierceAttack : BasicAASkill
{
    public GameObject prefab;
    public float projectileSpeed;
    public float damage;

    private float realDmg;

    public override void Execute(CharacterBehaviour behaviour, GameObject target = null)
    {
        realDmg = behaviour.CalculateAADamage(damage);
        GameObject arrow = Instantiate<GameObject>(prefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, target.transform.position.y, 0));
        arrow.GetComponent<ProjectileMovement>().Init(this, target.transform.position, projectileSpeed);
    }

    public override void DealDamage(HealthManager manager, GameObject projectile)
    {
        manager.Damage(realDmg, null, gameObject);
    }
}
