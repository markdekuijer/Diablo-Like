using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAoeLifestealSkill : AbbilitySkill
{
    [SerializeField] private List<GameObject> particles = new List<GameObject>();
    [SerializeField] private float radius;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float damage;
    [SerializeField] private float lifestealPercentage;
    [SerializeField] private HealthManager hpManager;
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
        Collider[] hitColliders = Physics.OverlapSphere(position, radius, mask);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].gameObject.GetComponent<HealthManager>().Damage(damage, null, gameObject);
            if (i < 25)
            {
                particles[i].gameObject.SetActive(true);
                particles[i].gameObject.transform.position = hitColliders[i].gameObject.transform.position;
            }//TODO still need to do dmg
        }

        duration = maxDuration;
        hpManager.HealDubble((damage / 100) * lifestealPercentage);
    }

    public override void Tick()
    {
        cooldown -= Time.deltaTime;

        if (duration >= 0)
        {
            duration -= Time.deltaTime;
            if (duration < 0)
            {
                foreach(GameObject g in particles)
                    g.gameObject.SetActive(false);
            }
        }
    }
}
