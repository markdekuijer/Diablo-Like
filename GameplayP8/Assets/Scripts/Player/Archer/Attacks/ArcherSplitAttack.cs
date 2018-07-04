using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSplitAttack : BasicAASkill
{
    public GameObject prefab;
    public float projectileSpeed;
    public float radius;
    public LayerMask mask;
    public float damage;

    private List<Transform> positions = new List<Transform>();
    private Transform bonusEnemy1;
    private Transform bonusEnemy2;

    private float realDmg;

    public override void Execute(CharacterBehaviour behaviour, GameObject target = null)
    {
        realDmg = behaviour.CalculateAADamage(damage);
        Collider[] hitColliders = Physics.OverlapSphere(target.transform.position, radius, mask);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if(hitColliders[i].gameObject != target)
                positions.Add(hitColliders[i].gameObject.transform);
        }

        if(positions.Count > 0)
        {
            bonusEnemy1 = GetClosestEnemy(positions.ToArray());
            GameObject miniArrow1 = ObjectPooler.SharedInstance.GetPooledObject(1);
            miniArrow1.SetActive(true);
            miniArrow1.transform.position = transform.position + new Vector3(0, 0.5f, 0);
            miniArrow1.transform.rotation = Quaternion.Euler(0, bonusEnemy1.position.y, 0);
            miniArrow1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            miniArrow1.GetComponent<ProjectileMovement>().Init(this, bonusEnemy1.position, projectileSpeed);
            positions.Remove(bonusEnemy1);
        }

        if (positions.Count > 0)
        {
            bonusEnemy2 = GetClosestEnemy(positions.ToArray());
            GameObject miniArrow2 = ObjectPooler.SharedInstance.GetPooledObject(1);
            miniArrow2.SetActive(true);
            miniArrow2.transform.position = transform.position + new Vector3(0, 0.5f, 0);
            miniArrow2.transform.rotation = Quaternion.Euler(0, bonusEnemy2.position.y, 0);
            miniArrow2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            miniArrow2.GetComponent<ProjectileMovement>().Init(this, bonusEnemy2.position, projectileSpeed);
            positions.Clear();
        }

        GameObject arrow = ObjectPooler.SharedInstance.GetPooledObject(1);
        arrow.SetActive(true);
        arrow.transform.position = transform.position + new Vector3(0, 0.5f, 0);
        arrow.transform.rotation = Quaternion.Euler(0, target.transform.position.y, 0);
        arrow.GetComponent<ProjectileMovement>().Init(this, target.transform.position, projectileSpeed);
    }

    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    public override void DealDamage(HealthManager manager, GameObject projectile)
    {
        if (manager != null)
        {
            if (projectile.name != "miniArrow")
                manager.Damage(realDmg, null, gameObject);
            else
                manager.Damage((realDmg / 100) * 75, null, gameObject);
        }
        projectile.SetActive(false);
    }
}
