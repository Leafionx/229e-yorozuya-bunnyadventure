using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    
    private GameManager gameManager;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Math.Clamp(currentHealth - damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger(AnimationStrings.hurt);
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger(AnimationStrings.die);
                GetComponent<PlayerController>().enabled = false;
                dead = true;
                
                gameManager.EndGame();
            }
        }
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    public void Respawn()
    {
       AddHealth(startingHealth);
       anim.ResetTrigger(AnimationStrings.die);
       anim.Play("player_idle");
    }
}
