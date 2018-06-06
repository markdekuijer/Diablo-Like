using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : CharacterAttack
{
    public override void Init(CharacterBehaviour behaviour)
    {
        base.Init(behaviour);
    }

    public override void Attack()
    {
        base.Attack();
        print("archer");
    }
}
