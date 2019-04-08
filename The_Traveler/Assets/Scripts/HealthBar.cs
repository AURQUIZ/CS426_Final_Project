using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    public float healthRatio { get; set; }

    public Slider healthBar;
    public Image fillBar;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        healthRatio = currentHealth / maxHealth;

        healthBar.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(10);
        }

    }

    void DealDamage(float damageValue)
    {
        currentHealth -= damageValue;
        healthRatio = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log("Health: " + currentHealth + "/" + maxHealth + " Ratio: " + (currentHealth / maxHealth));
        healthBar.value = CalculateHealth();

        fillBar.color = Color.Lerp(Color.red, Color.green, healthRatio);
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    void Die()
    {
        Debug.Log("Character died");
    }
}

