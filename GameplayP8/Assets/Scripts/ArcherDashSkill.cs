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

    protected override void Start()
    {
        base.Start();
        maxDuration = duration;
        duration = 0;
    }

    public override void Init(Vector3 position = default(Vector3))
    {
        if (GetCooldownProcent() > 0)
            return;

        cooldown = maxCooldown;
        duration = maxDuration;
        movement.InitSpecialMovement();
        movement.SetSpeed(dashSpeed);
        dashObj.SetActive(true);
    }

    public override void Tick()
    {
        cooldown -= Time.deltaTime;

        if (duration > 0)
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
