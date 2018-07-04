using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

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
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private CharacterAttack characterAttack;
    public AnimatorHook anim;
    public CharacterMovement characterMovement;

    [Header("States")]
    [SerializeField] private bool isStatic;
    [SerializeField] private bool isSlowed;
    [SerializeField] private bool isDead;
    //dit gaat nog nooit false, maar zou ook nooit true moeten zijn voor ranged
    //characters
    [SerializeField] private bool isApproachingEnemy;
    public bool isMoving;
    public bool isAttacking;

    [Header("Variables")]
    [SerializeField] private bool isRangedCharacter;
    [SerializeField] private bool hasGoal;
    [SerializeField] private GameObject interactionGoal;
    [SerializeField] private float interactionthreshold = 0.1f;
    public static CharStats characterStats;
    public static WeaponStats currentWeaponStats; //TODO dit net static gemaakt voor ItemDrop en DroppedItem
    public static ArmoreStats currentArmoreStats;
    public static Vector3 currentPosition;
    public WeaponStats stats;
    public int currentLevel;

    private int exp;

    private void Awake()
    {
        string statsString = "ArcherLevel";
        statsString += currentLevel.ToString();
        characterStats = Resources.Load<CharStats>("ScriptableStuff/CharacterStats/" + statsString);
        currentWeaponStats = Resources.Load<WeaponStats>("ScriptableStuff/Bows/Lvl1_BowCommon_V1");
        characterMovement.Init(agent, cam, this);
        characterAttack.Init(this);
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ExpHandler.Instance.GiveExp(30);
        GetBaseInput();
        HandleGoals();
        HandleAnimations();
        characterAttack.Tick();
    }

    #region Input

    public void GetBaseInput()
    {
        currentPosition = transform.position;
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
                HandleDirectInput(hit);
            if (Input.GetMouseButtonDown(1))
                HandleSecondaryInput();

            HandleIndirectInput();
        }
        if (isApproachingEnemy)
        {
            HandleTargets();
        }

        GetAbbilityInput(hit);
    }

    public void GetAbbilityInput(RaycastHit hit)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            characterAttack.currentAbbility.Init(hit.point);

        for (int i = 0; i < characterAttack.abbilityAttacks.Count; i++)
        {
            characterAttack.abbilityAttacks[i].Tick();
        }
    }

    public void HandleDirectInput(RaycastHit hit)
    {
        if (hit.transform.gameObject.CompareTag("Ally"))
        {
            hasGoal = true;
            interactionGoal = hit.transform.gameObject;
            characterMovement.SetMoveTarget(hit.point);
        }
        else if(Input.GetKey(KeyCode.LeftShift) || hit.transform.gameObject.CompareTag("Enemy"))
        {
            hasGoal = false;
            interactionGoal = null;
            if (isRangedCharacter)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    GameObject g = new GameObject(); //TODO make pool van ongeveer 20 voor invisable objects so you can find the target pos. inplaats van de pivot van het geraakte OBJ
                    g.transform.position = hit.point;
                    characterAttack.target = g;
                }
                else
                {
                    characterAttack.target = hit.transform.gameObject;
                }
                characterAttack.InitAttack();
            }
            else
            {
                isApproachingEnemy = true;
            }
        }
        else
        {
            characterMovement.SetMoveTarget(hit.point);
            isApproachingEnemy = false;
            hasGoal = false;
            interactionGoal = null;
        }
    }

    public void HandleSecondaryInput()
    {
        print("need to make this");
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
        characterAttack.HandleAttackTarget();
        return;
    }

    public void HandleInteractionGoal()
    {
        if(Vector3.Distance(transform.position, interactionGoal.transform.position) < interactionthreshold)
        {
            print(interactionGoal.name + " " + Time.time);
            StopMovement();
            hasGoal = false;
            interactionGoal = null;
            //activateGoalPurpose (missions,dialog,enteringRooms)
        }
    }

    public void StopMovement()
    {
        characterMovement.SetMoveTarget(transform.position);
    }

    #endregion

    public void HandleAnimations()
    {
        if (agent.velocity == Vector3.zero)
            isMoving = false;
        else
            isMoving = true;
    }

    public float CalculateAADamage(float dmg)
    {
        float returnDmg = 0;
        returnDmg = (dmg * currentWeaponStats.damage);
        return returnDmg;
    }

}
