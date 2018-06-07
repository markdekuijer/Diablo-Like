using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSplitAttack : BasicAASkill
{
    public GameObject prefab;
    public float range;
    public float divider;

    private void Start()
    {
        Execute();
    }

    public override void Execute(Vector3 targetPos = default(Vector3))
    {
        print("Fire");
        //Make arrow prefab
    }
}

