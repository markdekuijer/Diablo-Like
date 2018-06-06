using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float range;

    protected CharacterBehaviour behaviour;
    public Vector3 target;

    public virtual void Init(CharacterBehaviour behaviour)
    {
        this.behaviour = behaviour;
    }

    public virtual void Attack()
    {
        print("attack");
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
