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
    public Image healthFill;
    public CharacterController controller;
    public Animation anim;
    public AudioSource death;
    public AudioClip[] bodyHittingFloorClips;


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
        if (Input.GetKeyDown(KeyCode.X))
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

