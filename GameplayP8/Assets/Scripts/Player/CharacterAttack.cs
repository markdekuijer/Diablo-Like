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
    public BasicAASkill[] basicAttacks = new BasicAASkill[2];
    public AbbilitySkill[] abbilityAttacks = new AbbilitySkill[4];
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

    public void InitAttack(int attackIndex)
    {
        if (attackSpeed > 0 || basicAttacks[attackIndex] == null)
            return;

        inAttackDuration = maxInAttackDuration;
        behaviour.isAttacking = true;
        behaviour.StopMovement();
        behaviour.anim.TriggerAnim("Attack");
        attackSpeed = maxAttackSpeed;
        this.transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        Attack(target, attackIndex);//removeThisLaterWhenAnimsExist
    }

    public virtual void Attack(GameObject target, int attackIndex)
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

    public float GetAttackspeedAmount()
    {
        if (attackSpeed > 0)
            return (attackSpeed / maxAttackSpeed);
        else
            return 0;
    }

    public void HandleAttackTarget()
    {
        if(Vector3.Distance(transform.position,target.transform.position) <= range)
        {
           InitAttack(0); //TODO hardcoded to fix errrors for archer
                          //have to fix this later
        }
        else
        {
            print("outside ranged");
            behaviour.characterMovement.SetMoveTarget(target.transform.position);
        }
    }
}

[System.Serializable]
public abstract class Skill : MonoBehaviour
{
}

[System.Serializable]
public abstract class BasicAASkill : Skill
{
    public virtual void DealDamage(HealthManager manager = null, GameObject projectile = null)
    {
    }
    public abstract void Execute(CharacterBehaviour behaviour, GameObject target = null);
}

[System.Serializable]
public abstract class AbbilitySkill : Skill
{
    public float cooldown;
    protected float maxCooldown;

    protected virtual void Start()
    {
        maxCooldown = cooldown;
        cooldown = 0;
    }

    public virtual void Init(Vector3 position = default(Vector3))
    {
    }
    public virtual void Tick()
    {
    }
    public float GetCooldownProcent()
    {
        if (cooldown > 0f)
        {
            return ((float)cooldown / (float)maxCooldown);
        }
        else
            return 0f;
    }
    public float GetCooldown()
    {
        return cooldown;
    }
}

