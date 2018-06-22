using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private bool isPlayer;

    [Header("Stats")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float minHealth;
    [SerializeField] private float maxShield;
    [SerializeField] private float minShield;

    public event Action<float, HealthManager> DamageEvent;

    private float currentHealth, totalHealth;
    private float currentShield, totalShield;

	void Start()
    {
        DamageEvent += TakeDamage;

        if (!isPlayer)
        {
            totalHealth = UnityEngine.Random.Range(minHealth, maxHealth);
            currentHealth = totalHealth;

            totalShield = UnityEngine.Random.Range(minShield, maxShield);
            currentShield = totalShield;
        }
        else
        {
            totalHealth = 100;
            currentHealth = totalHealth;
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

    public void Damage(float dmg, HealthManager h = null)
    {
        DamageEvent(dmg, h);
    }

	public void TakeDamage(float dmg, HealthManager h = null)
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
                    EnemyDeath(gameObject.GetComponent<CharacterBehaviour>());
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
        gameObject.SetActive(false);
    }
}
    
