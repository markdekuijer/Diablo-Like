using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorHook : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private EnemyBrain brain;

    [HideInInspector] public bool walking;

    public void Tick()
    {
        anim.SetBool("Walking", walking);
    }

    public void PlayAnim(string animName)
    {
        anim.CrossFade(animName, 0.05f);
    }

    public void SetTrigger(string animName)
    {
        anim.SetTrigger(animName);
    }

    public void SetAnimSpeed(float speed)
    {
        anim.speed = speed;
    }
}
