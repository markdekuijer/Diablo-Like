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

    private float realDmg;

    public override void Execute(CharacterBehaviour behaviour, GameObject target = null)
    {
        realDmg = behaviour.CalculateAADamage(damage);
        GameObject arrow = ObjectPooler.SharedInstance.GetPooledObject(2);
        arrow.SetActive(true);
        arrow.transform.position = transform.position + new Vector3(0, 0.5f, 0);
        arrow.transform.rotation = Quaternion.Euler(0, target.transform.position.y, 0);
        arrow.GetComponent<ProjectileMovement>().Init(this, target.transform.position, projectileSpeed);
    }

    public override void DealDamage(HealthManager manager, GameObject projectile)
    {
        Collider[] hitColliders = Physics.OverlapSphere(manager.gameObject.transform.position, radius, mask);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].gameObject.GetComponent<HealthManager>().Damage(realDmg, null, gameObject);
        }
        projectile.SetActive(false);
    }
}
