using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBlizardProjectile : MonoBehaviour
{
    [SerializeField] private float slowAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyBrain b = other.GetComponent<EnemyBrain>();
            b.movement.GiveSlow(slowAmount, Mathf.Infinity);
            b.animHook.SetAnimSpeed(0.4f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyBrain b = other.GetComponent<EnemyBrain>();
            b.movement.slowDuration = 0;
            b.animHook.SetAnimSpeed(1f);
        }
    }
}
