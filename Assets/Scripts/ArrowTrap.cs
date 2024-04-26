using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField]
    public GameObject arrow;
    [SerializeField]
    public Transform firePoint;
    [SerializeField]
    public float projectileSpeed = 10f;
    [SerializeField]
    public float fireRate = 0.5f;
    [SerializeField]
    private float cooldownTime = 0f;

    private void Update()
    {
        if (Time.time >= cooldownTime)
        {
            Shoot();
            cooldownTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(arrow, firePoint.position, Quaternion.identity);
        
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        Vector2 shootDirection = Vector2.right;
        
        rb.velocity = shootDirection * projectileSpeed;
    }
}
