using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAoeAttack : BasicAASkill
{
    public GameObject prefab;
    public float projectileSpeed;
    public float damage;
    public float radius;
    public LayerMask mask;

    public override void Execute(Vector3 targetPos = default(Vector3))
    {
        GameObject arrow = Instantiate<GameObject>(prefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, targetPos.y, 0));
        arrow.GetComponent<ProjectileMovement>().Init(this, targetPos, projectileSpeed);
    }

    public override void DealDamage(HealthManager manager)
    {
        Collider[] hitColliders = Physics.OverlapSphere(manager.gameObject.transform.position, radius, mask);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].gameObject.GetComponent<HealthManager>().TakeDamage(damage);
        }
    }
}
