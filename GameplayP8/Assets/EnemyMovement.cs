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

    private float originalSpeed;

    private void Start()
    {
        originalSpeed = speed;
        agent.SetDestination(pos1);
    }


    void Update ()
    {
		if(transform.position == pos1)
        {
            agent.SetDestination(pos2);
            print("a");
        }
        if(transform.position == pos2)
        {
            agent.SetDestination(pos1);
            print("b");
        }
    }
}













































































































































































//nice meme