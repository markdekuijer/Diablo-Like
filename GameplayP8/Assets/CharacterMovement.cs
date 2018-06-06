using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float movementSpeed = 3.5f;

    private CharacterBehaviour behaviour;
    private NavMeshAgent agent;
    private Camera cam;

	public void Init(NavMeshAgent agent, Camera cam, CharacterBehaviour behaviour)
    {
        this.behaviour = behaviour;
        this.agent = agent;
        this.cam = cam;

        agent.speed = movementSpeed;
	}
	
	public void SetMoveTarget(Vector3 position)
    {
        agent.SetDestination(position);
	}
}
