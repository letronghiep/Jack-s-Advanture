using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float timeExist=3.0f;

    public Rigidbody2D rb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeExist-= Time.deltaTime;

        if (timeExist < 0)
        {
            Destroy(gameObject);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy enemy= collision.GetComponent<enemy>();
        BossHealth bss=collision.GetComponent<BossHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(60);
        }
        if(bss != null)
        {
            bss.TakeDamage(60);
        }

    }

}
