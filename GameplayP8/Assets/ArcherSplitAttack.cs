using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSplitAttack : BasicAASkill
{
    public GameObject prefab;
    public float projectileSpeed;
    public float range;
    public float divider;

    public override void Execute(Vector3 targetPos = default(Vector3))
    {
        print("Fire");
        GameObject arrow = Instantiate<GameObject>(prefab, transform);
        arrow.GetComponent<ProjectileMovement>().Init(this, targetPos,4);
    }

    public void DealDmg()
    {

    }
}

