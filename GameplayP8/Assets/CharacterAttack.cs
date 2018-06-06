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
    }

    public virtual void Attack()
    {
    }

    public void HandleAttackTarget()
    {
        if(Vector3.Distance(transform.position,target) < range)
        {
            Attack();
            behaviour.StopMovement();
        }
    }
}
