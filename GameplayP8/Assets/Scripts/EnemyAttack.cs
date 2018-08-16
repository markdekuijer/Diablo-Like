using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackRate;
    [SerializeField] private float maxAttackRange;
    [SerializeField] private float dmg;
    [SerializeField] private bool isArcher;
    [SerializeField] private GameObject archerArrow;
    private EnemyBrain brain;
    private bool canAttack;

    private float maxAttackRate;

	public virtual void Init(EnemyBrain brain)
    {
        this.brain = brain;
        maxAttackRate = attackRate;
    }

    public virtual void Tick()
    {
        CheckForAttack();
        attackRate -= Time.deltaTime;
    }

    public virtual void CheckForAttack()
    {
        canAttack = (attackRate <= 0);

        if (brain.movement.inRange && canAttack)
            InitAttack();
    }

    public virtual void InitAttack()
    {
        brain.movement.inRange = false;
        brain.movement.inAttack = true;
        attackRate = maxAttackRate;
        string attackString = "DS_onehand_attack";

        int i = Random.Range(0, 3);
        if (i == 0) attackString += "_A";
        else if (i == 1) attackString += "_B";
        else attackString += "_C";

        brain.animHook.PlayAnim(attackString);
    }

    public virtual void Attack()
    {
        if (isArcher)
        {
            //SpawnArrow;
            GameObject arrow = Instantiate(archerArrow, transform.position, Quaternion.Euler(transform.position - brain.movement.moveTarget.transform.position));
            arrow.transform.LookAt(brain.movement.moveTarget.transform.position);
            print("arrowSpawn Needed");
        }
        else if (Vector3.Distance(transform.position, brain.movement.moveTarget.transform.position) < maxAttackRange)
        {
            brain.movement.moveTarget.GetComponent<HealthManager>().Damage(dmg,brain.health);
        }
        else
            print("Missed Attack");
    }

    public virtual void ReenableMovement()
    {
        brain.movement.inAttack = false;
    }
}
