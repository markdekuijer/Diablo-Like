using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAoeSkill : AbbilitySkill
{
    [SerializeField] private GameObject obj;
    [SerializeField] private int iterations;
    [SerializeField] private float totalDuration;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float damage;

    private float iterationsLeft;
    private float iterationTime;
    private float maxIterationTime;

    protected override void Start()
    {
        base.Start();
    }

    public override void Init(Vector3 position = default(Vector3))
    {
        if (GetCooldownProcent() > 0)
            return;

        cooldown = maxCooldown;
        obj.transform.position = transform.position + Vector3.down;
        iterationsLeft = iterations;
        iterationTime = totalDuration / iterations;
        maxIterationTime = iterationTime;
    }

    public override void Tick ()
    {
        //obj.Play();
        cooldown -= Time.deltaTime;
        obj.transform.position = transform.position + Vector3.down;
        iterationTime -= Time.deltaTime;
        if(iterationTime <= 0 && iterationsLeft > 0)
        {
            iterationsLeft--;
            iterationTime = maxIterationTime;
            Execute();
        }
        if (iterationsLeft <= 0)
            obj.transform.position = new Vector3(-10, 0, -10);
	}

    public void Execute()
    {
        print("execute");
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, mask);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].gameObject.GetComponent<HealthManager>().Damage(damage, null, gameObject);
        }
    }
}
