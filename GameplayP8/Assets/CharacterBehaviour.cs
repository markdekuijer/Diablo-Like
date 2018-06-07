using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterBehaviour : MonoBehaviour
{
    /// <summary>
    /// todo list:
    /// rework skills from start
    /// set attacks up first with Lmb and Rmb. archer has infinity range (hold Shift for lmb fire instead of walking)
    /// rethink dmg system and projectile
    /// every 'skill' SHOULD have the same projectile probebly. maar moet ff kijken. los script mogelijk voor los objectile
    /// RETHINK attack states. (initAttack, ActualFire, OnHitRecieveDmg[mogelijk in projectile gebouwd{projectile virtual class}])
    /// get an animator
    /// bewaar auto-walk closer script/code voor melee characters. die hebben autowalk als je te ver bent
    /// maak pools
    /// rmb is alleen maar shooting. dus no worry about that, maar maak het
    /// maak SWS 4 types. explosive arrow, basic arrow, slow arrow(slow mechenic maken), EOA spread arrow
    /// </summary>

    [Header("On Startup")]
    [SerializeField] private Camera cam;
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private CharacterAttack characterAttack;
    public CharacterMovement characterMovement;

    [Header("States")]
    [SerializeField] private bool isStatic;
    [SerializeField] private bool isSlowed;
    [SerializeField] private bool isDead;
    public bool isAttacking;

    [Header("Variables")]
    [SerializeField] private bool hasGoal;
    [SerializeField] private GameObject interactionGoal;
    [SerializeField] private float interactionthreshold = 0.1f;
    [Space(15)]
    public bool hasTarget;
    public HealthManager enemyTarget;

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
        HandleTargets();
        characterAttack.Tick();
    }

    #region Input

    public void HandleDirectInput(RaycastHit hit)
    {
        if (hit.transform.gameObject.CompareTag("Enemy"))
        {
            hasTarget = true;
            enemyTarget = hit.transform.gameObject.GetComponent<HealthManager>();
            characterAttack.target = hit.transform.position;
            print("set enemy");
        }
        else if (hit.transform.gameObject.CompareTag("Ally"))
        {
            hasGoal = true;
            interactionGoal = hit.transform.gameObject;
        }
        else
        {
            print("reset");
            hasGoal = false;
            hasTarget = false;
            interactionGoal = null;
            enemyTarget = null;
        }

        characterMovement.SetMoveTarget(hit.point);
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
            Debug.LogError("No Remaining Goal. bugg somewhere");
            hasGoal = false;
        }
    }

    public void HandleTargets()
    {
        if (hasTarget)
        {
            if (enemyTarget != null)
            {
                characterAttack.target = enemyTarget.transform.position;
                characterAttack.HandleAttackTarget();
                return;
            }
            Debug.LogError("No Remaining Targets. bugg somewhere");
            hasTarget = false;
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
        characterMovement.SetMoveTarget(transform.position);
    }

    #endregion
}
