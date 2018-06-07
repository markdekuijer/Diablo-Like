using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition;
    private float projectileSpeed;

	public void Init(Skill skill, Vector3 targetPos, float projectileSpeed = 4)
    {
        print("inited");
        this.targetPosition = targetPos;
        this.projectileSpeed = projectileSpeed;
	}
	
	void Update ()
    {
        //transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, projectileSpeed * Time.deltaTime);
        if(transform.position == targetPosition)
        {
            //doDmg?HOW!!!
            gameObject.SetActive(false);
        }
	}
}
