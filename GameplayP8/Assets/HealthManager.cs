using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private bool isPlayer;

    [Header("Stats")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float minHealth;
    [SerializeField] private float maxShield;
    [SerializeField] private float minShield;

    private float currentHealth, totalHealth;
    private float currentShield, totalShield;

	void Start()
    {
        if (!isPlayer)
        {
            totalHealth = Random.Range(minHealth, maxHealth);
            currentHealth = totalHealth;

            totalShield = Random.Range(minShield, maxShield);
            currentShield = totalShield;
        }
        else
        {
            //totalHealth = characterStats.totalHealth;
            //totalShield = characterStats.totalShield;
        }

	}

    public void HealSingle(float hpHeal, float shieldHeal)
    {
        currentHealth += hpHeal;
        if (currentHealth > totalHealth)
            currentHealth = totalHealth;

        currentShield += shieldHeal;
        if (currentShield > totalShield)
            currentShield = totalShield;
    }

    public void HealDubble(float totalHeal)
    {
        if(totalHeal > (totalHealth - currentHealth))
        {
            float hpHeal = totalHeal - currentHealth;
            float shieldHeal = totalHeal - hpHeal;

            currentHealth += hpHeal;
            currentShield += shieldHeal;
        }
    }

	public void TakeDamage(float dmg, CharacterBehaviour character = null)
    {
        if (dmg <= currentShield)
        {
            currentShield -= dmg;
        }
        else
        {
            float healthDmg = dmg - currentShield;
            currentShield = 0;
            currentHealth -= healthDmg;
            //play particle
            //play animation

            if (currentHealth <= 0)
            {
                if (isPlayer)
                    PlayerDeath();
                else
                    EnemyDeath(character);
            }
        }
    }

    public void PlayerDeath()
    {

    }

    public void EnemyDeath(CharacterBehaviour character)
    {
        //handleDeathWithPool
        //deathAnimationCorotaine
        if(character != null)
                character.isAttacking = false;
        gameObject.SetActive(false);
    }
}
    
