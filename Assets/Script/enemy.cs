using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth=100;
    public int currentHealth;
    //public bool enemystate; 
    public GameObject deathEffect;
    public HeartBar heartBar;
    Rigidbody2D rb;
    void Start()
    {
        currentHealth = maxHealth;
        heartBar.SetMaxHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        heartBar.setHealth(currentHealth);
        animator.SetTrigger("Hurt");

        if(currentHealth<=0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died!");

        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
      
    }
}
