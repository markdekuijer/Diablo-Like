using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float range;
    [SerializeField] private float attackSpeed;

    [HideInInspector] public Vector3 target;
    protected CharacterBehaviour behaviour;
    private float maxAttackSpeed;

    public virtual void Init(CharacterBehaviour behaviour)
    {
        this.behaviour = behaviour;
        maxAttackSpeed = attackSpeed;
    }

    public void InitAttack()
    {
        behaviour.isAttacking = true;
        behaviour.StopMovement();
        attackSpeed = maxAttackSpeed;
        this.transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
        //playAnim;
        Attack(target);//removeThisLaterWhenAnimsExist
    }

    public virtual void Attack(Vector3 targetPos)
    {
        //getCurrentSkill
        //takeThatEffect
        //behaviour.enemyTarget.TakeDamage(1, behaviour);
    }

    public virtual void Tick()
    {
        attackSpeed -= Time.deltaTime;
    }

    public void HandleAttackTarget()
    {
        if(Vector3.Distance(transform.position,target) <= range)
        {
            if (attackSpeed > 0)
                return;
            
            InitAttack();
        }
        else
        {
            print("outside ranged");
            behaviour.characterMovement.SetMoveTarget(target);
        }
    }
}

public abstract class Skill : MonoBehaviour
{
    public abstract void Execute(Vector3 position = default(Vector3));
}

public abstract class BasicAASkill : Skill
{
    public virtual void DealDamage(HealthManager manager = null, GameObject projectile = null)
    {
    }
}

public abstract class AbbilitySkill : Skill
{
}

