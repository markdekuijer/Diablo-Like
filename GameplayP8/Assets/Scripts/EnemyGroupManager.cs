using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupManager : MonoBehaviour
{
    [SerializeField] private List<EnemyBrain> enemys = new List<EnemyBrain>();

    private void Start()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].Init(this);
        }
    }

    private void Update()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            if(enemys[i].health.isDead)
                continue;

            enemys[i].Tick();
        }
    }

    public void AlertOthers(EnemyBrain e, GameObject target)
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].movement.moveTarget = target;
            enemys[i].alerted = true;
            enemys[i].health.DamageEvent -= enemys[i].OnHitAlert;
        }
    }
}
