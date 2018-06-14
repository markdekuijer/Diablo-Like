using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private float projectileSpeed;
    private BasicAASkill skill;

	public void Init(BasicAASkill skill, Vector3 targetPos, float projectileSpeed = 4, float offset = 0)
    {
        this.skill = skill;
        this.projectileSpeed = projectileSpeed;
        transform.LookAt(new Vector3(targetPos.x, transform.position.y,targetPos.z));
        transform.Rotate(new Vector3(0, offset, 0));
	}
	
	void Update ()
    {
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            skill.DealDamage(other.gameObject.GetComponent<HealthManager>(),gameObject);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            skill.DealDamage();
            gameObject.SetActive(false);
        }
    }
}
