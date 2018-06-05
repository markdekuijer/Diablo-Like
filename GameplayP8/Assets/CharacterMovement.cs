using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    private Camera cam;

	void Start ()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Transform objectHit = hit.transform;
                m_Agent.SetDestination(hit.point);
                print(hit.point);
            }
        }
	}
}
