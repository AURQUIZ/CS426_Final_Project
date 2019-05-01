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
    public TravelBar mTBar;
    public Image healthFill;
    public CharacterController controller;
    public Animation anim;
    public AudioSource death;
    public AudioClip[] bodyHittingFloorClips;
    private float healthRegen = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();

        maxHealth = 100f;
        currentHealth = maxHealth;
        healthRatio = currentHealth / maxHealth;

        healthBar.value = CalculateHealth();
        healthFill.color = Color.Lerp(Color.red, Color.green, CalculateHealth());
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentHealth != 0 && currentHealth < 100)
        {
            currentHealth += Time.deltaTime * healthRegen;

            healthBar.value = CalculateHealth();
            healthFill.color = Color.Lerp(Color.red, Color.green, CalculateHealth());
        }
        if (Input.GetKeyDown(KeyCode.Q) && mTBar.barStatus >= 1.0f)
        {
            DealDamage(10);
        }



    }

    void DealDamage(float damageValue)
    {
        currentHealth -= damageValue;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log("Health: " + currentHealth + "/" + maxHealth + " Ratio: " + CalculateHealth());
        healthBar.value = CalculateHealth();
        healthFill.color = Color.Lerp(Color.red, Color.green, CalculateHealth());
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    void BodyHittingFloor()
    {
        AudioClip clip = GetClip();
        death.PlayOneShot(clip, 0.5f); //plays clip
    }

    private AudioClip GetClip()
    {
        return bodyHittingFloorClips[UnityEngine.Random.Range(0, bodyHittingFloorClips.Length)];
    }


    void Die()
    {
        Debug.Log("Character died");
        death.Play();
        anim.Play("die");
        this.gameObject.GetComponentInChildren<Movement>().canMove = false;
    }
}

