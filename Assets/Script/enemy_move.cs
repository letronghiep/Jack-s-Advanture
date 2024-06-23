using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public Animator animator;
    public float changeTime = 3.0f;
    SpriteRenderer sprite;
    Rigidbody2D rigidbody2D;
    public int dame=10;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        sprite= GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
            sprite.flipX = !sprite.flipX;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetBool("isMoving", false);

        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetBool("isMoving", true);
            
        }

        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        move player = other.gameObject.GetComponent<move>();

        if (player != null)
        {
            player.ChangeHealth(-dame);
            Debug.Log("VACHAM");
        }
    }
}
