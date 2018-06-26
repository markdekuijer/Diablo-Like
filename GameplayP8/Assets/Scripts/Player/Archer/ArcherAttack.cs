using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : CharacterAttack
{
    public override void Init(CharacterBehaviour behaviour)
    {
        base.Init(behaviour);
        currentAA = basicAttacks[0];
        currentAbbility = abbilityAttacks[0];
    }

    public override void Tick()
    {
        base.Tick();
        if (Input.GetKeyDown(KeyCode.U))
            currentAA = basicAttacks[0];
        if (Input.GetKeyDown(KeyCode.I))
            currentAA = basicAttacks[1];
        if (Input.GetKeyDown(KeyCode.O))
            currentAA = basicAttacks[2];
        if (Input.GetKeyDown(KeyCode.P))
            currentAA = basicAttacks[3];

    }

    public override void Attack(GameObject target)
    {
        currentAA.Execute(behaviour , target);
    }
}
