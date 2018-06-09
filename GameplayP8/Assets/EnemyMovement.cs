﻿using System.Collections;
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

    public bool isSlowed;
    public float slowDuration;
    public float slowAmount;

    private float originalSpeed;

    private void Start()
    {
        originalSpeed = speed;
        agent.SetDestination(pos1);
    }


    void Update ()
    {
        WaypointWalking();
        HandleMovementSpeed();
    }

    public void GiveSlow(float amount, float duration)
    {
        isSlowed = true;
        slowDuration = duration;
        slowAmount = amount;
    }

    public void HandleMovementSpeed()
    {
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
            print("a");
        }
        if (transform.position == pos2)
        {
            agent.SetDestination(pos1);
            print("b");
        }
    }
}













































































































































































//nice meme