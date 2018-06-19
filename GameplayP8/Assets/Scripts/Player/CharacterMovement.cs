using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    [Header("On Startup")]
    private CharacterBehaviour behaviour;
    private NavMeshAgent agent;
    private Camera cam;

    [Header("States")]
    private bool inSpecialMovement;

    [Header("Variables")]
    [SerializeField] private float movementSpeed = 3.5f;

    private float orignalMovementSpeed;
    public float OriginalMovementSpeed { get { return orignalMovementSpeed; } }

    private Vector3 currentTarget;
    public Vector3 CurrentTarget {get { return currentTarget; } }



	public void Init(NavMeshAgent agent, Camera cam, CharacterBehaviour behaviour)
    {
        orignalMovementSpeed = movementSpeed;
        this.behaviour = behaviour;
        this.agent = agent;
        this.cam = cam;

        agent.speed = movementSpeed;
	}
	
	public void SetMoveTarget(Vector3 position)
    {
        currentTarget = position;
        agent.SetDestination(position);
	}

    public void SetSpeed(float speed)
    {
        agent.speed = speed;
    }

    public void InitSpecialMovement()
    {
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
        inSpecialMovement = true;
    }
    
    public void DisableSpecialMovement()
    {
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
        inSpecialMovement = false;
    }
}
