using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("On Startup")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 pos1;
    [SerializeField] private Vector3 pos2;
    [SerializeField] private EnemyBrain brain;

    [Header("Stats")]
    public bool isRooted;
    public bool isSlowed;
    public bool inRange;
    public bool inAttack;

    [Header("Variables")]
    [SerializeField] private bool ignoreWaypoints;
    [SerializeField] private float hitRange;
    public GameObject moveTarget;

    [Header("Others")]
    public float slowDuration;
    public float slowAmount;

    private float originalSpeed;

    private void Start()
    {
        originalSpeed = speed;
        if(!ignoreWaypoints)
            agent.SetDestination(pos1);
    }


    void Update ()
    {
        if(!ignoreWaypoints)
            WaypointWalking();
        if(!inAttack)
            HandleTargetMoving();
        HandleMovementSpeed();
        HandleRoot();
    }

    public void GiveSlow(float amount, float duration)
    {
        isSlowed = true;
        slowDuration = duration;
        slowAmount = amount;
    }

    public void HandleMovementSpeed()
    {
        brain.animHook.walking = !agent.isStopped;
        if (isSlowed)
        {
            slowDuration -= Time.deltaTime;
            if (slowDuration <= 0)
            {
                isSlowed = false;
                speed = originalSpeed;
            }
            else
            {
                speed = originalSpeed - slowAmount;
            }

            agent.speed = speed;
        }
    }

    public void WaypointWalking()
    {
        if (transform.position == pos1)
        {
            agent.SetDestination(pos2);
        }
        if (transform.position == pos2)
        {
            agent.SetDestination(pos1);
        }
    }

    public void HandleTargetMoving()
    {
        if(moveTarget != null)
        {
            agent.SetDestination(moveTarget.transform.position);
            inRange = Vector3.Distance(moveTarget.transform.position, transform.position) < hitRange;
        }
    }
    public void SetTarget(GameObject g)
    {
        if (!gameObject.activeSelf)
            return;
        moveTarget = g;
    }

    public void HandleRoot()
    {
        if (isRooted)
        {
            agent.speed = 0;
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
        }
        else
        {
            agent.speed = speed;
            agent.isStopped = false;
        }
    }
}













































































































































































//nice meme