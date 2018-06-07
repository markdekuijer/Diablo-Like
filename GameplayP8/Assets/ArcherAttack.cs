using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : CharacterAttack
{
    public List<BasicAASkill> basicAttacks = new List<BasicAASkill>();
    public BasicAASkill currentAA;

    public override void Init(CharacterBehaviour behaviour)
    {
        base.Init(behaviour);
        currentAA = basicAttacks[0];
    }

    public override void Tick()
    {
        base.Tick();
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentAA = basicAttacks[0];
        if (Input.GetKeyDown(KeyCode.Alpha2))
            currentAA = basicAttacks[1];
        if (Input.GetKeyDown(KeyCode.Alpha3))
            currentAA = basicAttacks[2];
        if (Input.GetKeyDown(KeyCode.Alpha4))
            currentAA = basicAttacks[3];
    }

    public override void Attack(Vector3 targetPos)
    {
        if (behaviour == null)
            print("rip");
        base.Attack(targetPos);
        currentAA.Execute(behaviour.enemyTarget.gameObject.transform.position);
        //behaviour.enemyTarget.TakeDamage(1, behaviour);
    }
}
