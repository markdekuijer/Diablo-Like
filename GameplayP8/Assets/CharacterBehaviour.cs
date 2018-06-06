using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterBehaviour : MonoBehaviour
{
    [Header("On Startup")]
    [SerializeField] private Camera cam;
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private CharacterAttack characterAttack;
    [SerializeField] private CharacterMovement characterMovement;

    [Header("States")]
    [SerializeField] private bool isStatic;

    [Header("Variables")]
    [SerializeField] private bool hasGoal;
    [SerializeField] private GameObject interactionGoal;
    [SerializeField] private float interactionthreshold = 0.1f;

    [SerializeField] private bool hasTarget;
    [SerializeField] private GameObject enemyTarget;

    private void Start()
    {
        characterMovement.Init(agent, cam, this);
        characterAttack.Init(this);
    }

    void Update ()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
                HandleDirectInput(hit);

            HandleIndirectInput();
        }

        HandleGoals();
    }
    #region Input

    public void HandleDirectInput(RaycastHit hit)
    {
        if (hit.transform.gameObject.CompareTag("Enemy"))
        {
            hasGoal = true;
            enemyTarget = hit.transform.gameObject;
            characterAttack.target = hit.transform.position;
            print("set enemy");
            //fixBugHiero hij zet geen enemy
        }
        if (hit.transform.gameObject.CompareTag("Ally"))
        {
            hasGoal = true;
            interactionGoal = hit.transform.gameObject;
        }
        else
        {
            hasGoal = false;
            interactionGoal = null;
            enemyTarget = null;
        }

        characterMovement.SetGoal(hit.point);
    }

    public void HandleIndirectInput()
    {
        //displayGraphics
    }

    #endregion


    #region Goals

    public void HandleGoals()
    {
        if (hasGoal)
        {
            if (interactionGoal != null)
            {
                HandleInteractionGoal();
                return;
            }
            if (characterAttack)
            {
                characterAttack.HandleAttackTarget();
                return;
            }
            Debug.LogError("No Remaining Goal. bugg somewhere");
            hasGoal = false;
        }
    }

    public void HandleInteractionGoal()
    {
        if(Vector3.Distance(transform.position, interactionGoal.transform.position) < interactionthreshold)
        {
            print(interactionGoal.name + " " + Time.time);
            StopMovement();
            hasGoal = false;
            interactionGoal = null;
        }
    }

    public void StopMovement()
    {
        characterMovement.SetGoal(transform.position);
    }
    #endregion
}
