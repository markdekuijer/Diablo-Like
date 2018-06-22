using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBlizzardSkill : AbbilitySkill
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

    public override void Init(Vector3 position = default(Vector3))
    {
        obj.SetActive(true);
        obj.transform.position = position;
        iterationsLeft = iterations;
        iterationTime = totalDuration / iterations;
        maxIterationTime = iterationTime;
    }

    public override void Tick()
    {
        //obj.Play();
        iterationTime -= Time.deltaTime;
        if (iterationTime <= 0 && iterationsLeft > 0)
        {
            iterationsLeft--;
            iterationTime = maxIterationTime;
            Execute();
        }
        if (iterationsLeft <= 0)
            obj.SetActive(false);
    }

    public void Execute()
    {
        print("execute");
        Collider[] hitColliders = Physics.OverlapSphere(obj.transform.position, radius, mask);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].gameObject.GetComponent<HealthManager>().Damage(damage, null, gameObject);
        }
    }
}

