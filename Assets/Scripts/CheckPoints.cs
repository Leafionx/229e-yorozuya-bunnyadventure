using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private Transform currentCheckpoint;
    private Health playerHealth;
    public ParticleSystem particleSystem1;
    public ParticleSystem particleSystem2;
    public ParticleSystem particleSystem3;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartParticles();
            
        }

        if (other.transform.tag == "Checkpoint")
        {
            currentCheckpoint = other.transform;
            other.GetComponent<Collider>().enabled = false;
        }
    }

    private void StartParticles()
    {
        if (particleSystem1 != null)
        {
            particleSystem1.Play();
        }

        if (particleSystem2 != null)
        {
            particleSystem2.Play();
        }

        if (particleSystem3 != null)
        {
            particleSystem3.Play();
        }
    }
}
