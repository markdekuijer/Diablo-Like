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

    protected override void Start()
    {
        base.Start();
        maxDuration = duration;
    }

    public override void Init(Vector3 position = default(Vector3))
    {
        if (GetCooldownProcent() > 0)
            return;

        cooldown = maxCooldown;
        obj.transform.position = transform.position + Vector3.down;
        duration = maxDuration;
        healthManager.HealDubble(heal);
    }

    public override void Tick()
    {
        cooldown -= Time.deltaTime;

        if (duration >= 0)
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
