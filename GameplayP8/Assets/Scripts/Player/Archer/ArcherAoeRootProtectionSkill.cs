using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAoeRootProtectionSkill : AbbilitySkill
{
    [SerializeField] private List<GameObject> particles = new List<GameObject>();
    [SerializeField] private float duration;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float damage;
    [SerializeField] private float protectionDebuff;

    private List<EnemyMovement> enemys = new List<EnemyMovement>();
    private float maxDuration;

    private void Start()
    {
        maxDuration = duration;
    }

    public override void Init(Vector3 position = default(Vector3))
    {
        enemys.Clear();
        Collider[] hitColliders = Physics.OverlapSphere(position, radius, mask);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].gameObject.GetComponent<HealthManager>().Damage(damage);
            enemys.Add(hitColliders[i].gameObject.GetComponent<EnemyMovement>());
            if(i < 25)
            {
                particles[i].gameObject.SetActive(true);
                particles[i].gameObject.transform.position = hitColliders[i].gameObject.transform.position;
            }
        }

        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].isRooted = true;
        }
        duration = maxDuration;

        //TODO reduce protections
    }

    public override void Tick()
    {
        if(duration >= 0)
        {
            duration -= Time.deltaTime;
            if(duration < 0)
            {
                for (int i = 0; i < enemys.Count; i++)
                {
                    enemys[i].isRooted = false;
                    particles[i].gameObject.SetActive(false);
                }

                //regain protections
            }
        }
    }
}
