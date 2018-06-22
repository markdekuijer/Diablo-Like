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

    public override void Execute(GameObject target = null)
    {
        Collider[] hitColliders = Physics.OverlapSphere(target.transform.position, radius, mask);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if(hitColliders[i].gameObject != target)
                positions.Add(hitColliders[i].gameObject.transform);
        }

        if(positions.Count > 0)
        {
            bonusEnemy1 = GetClosestEnemy(positions.ToArray());
            GameObject miniArrow1 = Instantiate<GameObject>(prefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, bonusEnemy1.position.y, 0));
            miniArrow1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            miniArrow1.GetComponent<ProjectileMovement>().Init(this, bonusEnemy1.position, projectileSpeed);
            miniArrow1.name = "miniArrow";
            positions.Remove(bonusEnemy1);
        }

        if (positions.Count > 0)
        {
            bonusEnemy2 = GetClosestEnemy(positions.ToArray());
            GameObject miniArrow2 = Instantiate<GameObject>(prefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, bonusEnemy2.position.y, 0));
            miniArrow2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            miniArrow2.GetComponent<ProjectileMovement>().Init(this, bonusEnemy2.position, projectileSpeed);
            miniArrow2.name = "miniArrow";
            positions.Clear();
        }

        GameObject arrow = Instantiate<GameObject>(prefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, target.transform.position.y, 0));
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
                manager.Damage(damage , null, gameObject);
            else
                manager.Damage((damage / 100) * 75, null, gameObject);
        }
        projectile.SetActive(false);
    }
}
