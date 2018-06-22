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
        //playAnim;
        //point in anim will init attack
        Attack();
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
        ReenableMovement();
    }

    public void ReenableMovement()
    {
        brain.movement.inAttack = false;
    }
}
