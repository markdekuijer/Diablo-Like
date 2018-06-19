using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherHealSkill : AbbilitySkill
{
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private float heal;
    [SerializeField] private GameObject obj;
    [SerializeField] private float duration;
    private float maxDuration;

    private void Start()
    {
        maxDuration = duration;
    }

    public override void Init(Vector3 position = default(Vector3))
    {
        obj.transform.position = transform.position + Vector3.down;
        duration = maxDuration;
        healthManager.HealDubble(heal);
    }

    public override void Tick()
    {
        if(duration >= 0)
        {
            obj.transform.position = transform.position + Vector3.down;
            duration -= Time.deltaTime;
            if(duration <= 0)
            {
                obj.transform.position = Vector3.zero;
            }
        }
    }
}
