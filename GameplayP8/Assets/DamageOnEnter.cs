using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnEnter : MonoBehaviour
{
    [SerializeField] private float dmg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HealthManager hp = other.gameObject.GetComponent<HealthManager>();
            if(hp != null)
            {
                hp.Damage(dmg);
            }
        }       
    }
}
