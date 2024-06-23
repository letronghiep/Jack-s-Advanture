using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 500;
    public GameObject finishpoint;
    float timer = 3.0f;
    public HeartBar heartBar;
    public Animator anim;
    void Start()
    {
        heartBar.SetMaxHealth(health);
    }
    private void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        
        health -= damage;

        GetComponent<Animator>().SetTrigger("Hurt");

        heartBar.setHealth(health);
        if (health <= (health / 2))
        {
            GetComponent<Animator>().SetTrigger("StageTwo");
        }
        if (health <= 0)
        {
            finishpoint.SetActive(true);
            Die();
        }
    }

    void Die()
    {
        GetComponent<Animator>().SetTrigger("Dead");
        

    }
}
