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
            other.GetComponent<EnemyMovement>().GiveSlow(slowAmount, Mathf.Infinity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyMovement>().slowDuration = 0;
        }
    }
}
