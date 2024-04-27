using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float fireRate = 0.5f;
    private float cooldownTime = 0f;

    private void Update()
    {
        if (Time.time >= cooldownTime)
        {
            Shoot();
            cooldownTime = Time.time + 1f / fireRate;
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(arrow, firePoint.position, Quaternion.identity);
        
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        
        Vector2 shootDirection = (firePoint.right).normalized;
        
        rb.velocity = shootDirection * projectileSpeed;
    }
}
