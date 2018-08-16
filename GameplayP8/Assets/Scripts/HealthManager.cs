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
    [SerializeField] private ItemDrop itemDrop;
    [SerializeField] private GameUIManager UI;

    public event Action<float, HealthManager, GameObject> DamageEvent;
    public event Action<float, HealthManager, GameObject> HealEvent;

    [SerializeField] private float currentHealth, totalHealth;
    private float currentShield, totalShield;
    public bool isDead;

    public float GetMaxHp { get { return totalHealth; } }
    public float GetCurrentHp { get { return currentHealth; } }


    void Start()
    {
        DamageEvent += TakeDamage;
        HealEvent += HealSingle;

        if (!isPlayer)
        {
            totalHealth = UnityEngine.Random.Range(minHealth, maxHealth);
            currentHealth = totalHealth;

            totalShield = UnityEngine.Random.Range(minShield, maxShield);
            currentShield = totalShield;
        }
        else
        {
            totalHealth = CharacterBehaviour.characterStats.health;
            maxShield = 0;
            currentShield = 0;
            currentHealth = totalHealth;
            UI.Init();
            //totalHealth = characterStats.totalHealth;
            //totalShield = characterStats.totalShield;
        }

	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isPlayer)
            MaxHP();
    }

    public void HealSingle(float hpHeal, HealthManager h = null, GameObject g = null)
    {
        currentHealth += hpHeal;
        if (currentHealth > totalHealth)
            currentHealth = totalHealth;
    }

    public void Heal(float hp)
    {
        HealEvent(hp, this, null);
    }

    public void MaxHP()
    {
        currentHealth = 100;
    }

    public void Damage(float dmg, HealthManager h = null, GameObject g = null)
    {
        DamageEvent(dmg, h, g);
    }

	public void TakeDamage(float dmg, HealthManager h = null, GameObject g = null)
    {
        GameObject go = ObjectPooler.SharedInstance.GetPooledObject(0);
        go.GetComponent<DamageShow>().Init(Mathf.RoundToInt(dmg));
        go.transform.position = transform.position + Vector3.up * 2;
        go.SetActive(true);

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
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        isDead = true;
    }

    public void EnemyDeath(CharacterBehaviour character)
    {
        //handleDeathWithPool
        //deathAnimationCorotaine
        isDead = true;
        if(itemDrop != null)
            itemDrop.DropItemChange();
        gameObject.SetActive(false);
    }
}
    
