using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    private CharacterBehaviour behaviour;
    private NavMeshAgent agent;
    private Camera cam;

	public void Init(NavMeshAgent agent, Camera cam, CharacterBehaviour behaviour)
    {
        this.behaviour = behaviour;
        this.agent = agent;
        this.cam = cam;
	}
	
	public void SetGoal(Vector3 position)
    {
        agent.SetDestination(position);
	}
}
