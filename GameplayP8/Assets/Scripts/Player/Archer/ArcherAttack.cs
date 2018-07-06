using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : CharacterAttack
{
    public override void Init(CharacterBehaviour behaviour)
    {
        base.Init(behaviour);
    }

    public override void Tick()
    {
        base.Tick();
    }

    public override void Attack(GameObject target, int attackIndex)
    {
        basicAttacks[attackIndex].Execute(behaviour , target);
    }
}
