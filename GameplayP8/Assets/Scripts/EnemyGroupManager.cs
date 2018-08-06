using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupManager : MonoBehaviour
{
    [SerializeField] private EnemyBrain[] enemys;

    private void Start()
    {
        enemys = GetComponentsInChildren<EnemyBrain>();
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].Init(this);
        }
    }

    private void Update()
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            if(enemys[i].health.isDead)
                continue;

            enemys[i].Tick();
        }
    }

    public void AlertOthers(EnemyBrain e, GameObject target)
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].movement.moveTarget = target;
            enemys[i].alerted = true;
            enemys[i].health.DamageEvent -= enemys[i].OnHitAlert;
        }
    }
}
