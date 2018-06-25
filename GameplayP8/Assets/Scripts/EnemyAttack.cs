using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackRate;
    [SerializeField] private float maxAttackRange;
    [SerializeField] private float dmg;
    private EnemyBrain brain;
    private bool canAttack;

    private float maxAttackRate;

	public void Init(EnemyBrain brain)
    {
        this.brain = brain;
        maxAttackRate = attackRate;
    }

    public void Tick()
    {
        CheckForAttack();
        attackRate -= Time.deltaTime;
    }

    public void CheckForAttack()
    {
        canAttack = (attackRate <= 0);

        if (brain.movement.inRange && canAttack)
            InitAttack();
    }

    public void InitAttack()
    {
        attackRate = maxAttackRate;
        brain.movement.inAttack = true;
        string attackString = "DS_onehand_attack";

        int i = Random.Range(0, 3);
        if (i == 0) attackString += "_A";
        else if (i == 1) attackString += "_B";
        else attackString += "_C";

        brain.animHook.PlayAnim(attackString);
    }

    public void Attack()
    {
        if(Vector3.Distance(transform.position, brain.movement.moveTarget.transform.position) < maxAttackRange)
        {
            brain.movement.moveTarget.GetComponent<HealthManager>().Damage(dmg,brain.movement.moveTarget.GetComponent<HealthManager>());
            print("Dealth Dmg");
        }
        else
            print("Missed Attack");
    }

    public void ReenableMovement()
    {
        brain.movement.inAttack = false;
    }
}
