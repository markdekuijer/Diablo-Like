using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherDashSkill : AbbilitySkill
{
    [SerializeField] private CharacterMovement movement;
    [SerializeField] private float duration;
    [SerializeField] private float dashSpeed;
    [SerializeField] private GameObject dashObj;

    private float maxDuration;

    private void Start()
    {
        maxDuration = duration;
        duration = 0;
    }

    public override void Init(Vector3 position = default(Vector3))
    {
        duration = maxDuration;
        movement.InitSpecialMovement();
        movement.SetSpeed(dashSpeed);
        dashObj.SetActive(true);
    }

    public override void Tick()
    {
        if(duration > 0)
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                movement.DisableSpecialMovement();
                movement.SetSpeed(movement.OriginalMovementSpeed);
                dashObj.SetActive(false);
            }
        }
    }
}
