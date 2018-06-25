using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHook : MonoBehaviour
{
    [SerializeField] private float afkDuration;
    [SerializeField] private CharacterBehaviour behaviour;
    [SerializeField] private Animator anim;

    private bool isMoving;
    private float maxAfkDuration;

	void Start ()
    {
        maxAfkDuration = afkDuration;
	}

    private void Update()
    {
        isMoving = behaviour.isMoving;
        AfkHandler();
        SetAnimVariables();
    }

    public void AfkHandler()
    {
        if (!isMoving && !behaviour.isAttacking)
        {
            afkDuration -= Time.deltaTime;
            if (afkDuration <= 0)
            {
                TriggerAnim("Idle");
                afkDuration = maxAfkDuration;
            }
        }
    }

    public void SetAnimVariables()
    {
        anim.SetBool("isMoving", isMoving);
    }

    public void TriggerAnim(string triggerTag)
    {
        anim.SetTrigger(triggerTag);
    }

    public void PlayAnimation(string animationName)
    {
        anim.CrossFade(animationName, 0.1f);
    }
    
    public void SetAnimSpeed(float speed)
    {
        anim.speed = speed;
    }
}
