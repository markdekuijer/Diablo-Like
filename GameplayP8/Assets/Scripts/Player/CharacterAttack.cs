using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float range;
    [SerializeField] private float attackSpeed;

    [Header("Variables")]
    [SerializeField] private float inAttackDuration;
    public List<BasicAASkill> basicAttacks = new List<BasicAASkill>();
    public List<AbbilitySkill> abbilityAttacks = new List<AbbilitySkill>();
    public BasicAASkill currentAA;
    public AbbilitySkill currentAbbility;

    [HideInInspector] public GameObject target;
    protected CharacterBehaviour behaviour;

    private float maxAttackSpeed;
    private float maxInAttackDuration;

    public virtual void Init(CharacterBehaviour behaviour)
    {
        this.behaviour = behaviour;
        maxAttackSpeed = attackSpeed;
        maxInAttackDuration = inAttackDuration;
    }

    public void InitAttack()
    {
        inAttackDuration = maxInAttackDuration;
        behaviour.isAttacking = true;
        behaviour.StopMovement();
        behaviour.anim.TriggerAnim("Attack");
        attackSpeed = maxAttackSpeed;
        this.transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        Attack(target);//removeThisLaterWhenAnimsExist
    }

    public virtual void Attack(GameObject target)
    {
        //getCurrentSkill
        //takeThatEffect
        //behaviour.enemyTarget.TakeDamage(1, behaviour);
    }

    public virtual void Tick()
    {
        attackSpeed -= Time.deltaTime;
        if (behaviour.isAttacking)
        {
            inAttackDuration -= Time.deltaTime;
            if(inAttackDuration <= 0)
            {
                behaviour.isAttacking = false;
            }
        }
    }

    public void HandleAttackTarget()
    {
        if(Vector3.Distance(transform.position,target.transform.position) <= range)
        {
            if (attackSpeed > 0)
                return;
            
            InitAttack();
        }
        else
        {
            print("outside ranged");
            behaviour.characterMovement.SetMoveTarget(target.transform.position);
        }
    }
}

public abstract class Skill : MonoBehaviour
{
}

public abstract class BasicAASkill : Skill
{
    public virtual void DealDamage(HealthManager manager = null, GameObject projectile = null)
    {
    }
    public abstract void Execute(GameObject target = null);
}

public abstract class AbbilitySkill : Skill
{
    public virtual void Init(Vector3 position = default(Vector3))
    {
    }
    public virtual void Tick()
    {
    }
}

