using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public EnemyMovement movement;
    public HealthManager health;
    public EnemyAttack attack;
    public GameObject target;

    public bool alerted;

    private EnemyGroupManager groupBrain;

    public void Init(EnemyGroupManager groupBrain)
    {
        attack.Init(this);
        this.groupBrain = groupBrain;
        health.DamageEvent += OnHitAlert;
    }

    public void Tick()
    {
        attack.Tick();
    }

    public void OnHitAlert(float f, HealthManager h, GameObject target)
    {
        groupBrain.AlertOthers(this, target);
    }
}
