using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight=false;
    float jumpPower = 8f;
    public float timeInvincible = 2.0f;
    bool isGrounded =false;
    public int maxHealth = 200;
    public int health { get { return currentHealth; } }
    int currentHealth;
    [SerializeField] public GameObject skill;
    bool isInvincible;
    float invincibleTimer;
    public HeartBar heartBar;
    Rigidbody2D rb;
    Animator animator;
    public GameObject deadscreen;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager= GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        currentHealth = maxHealth;
        heartBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.isActive == true)
            return;
        horizontalInput = Input.GetAxis("Horizontal");
        
        FlipSprite();
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
            audioManager.PlaySFX(audioManager.jump);
        }
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("isJumping", false);
            isGrounded = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            audioManager.PlaySFX(audioManager.attack);
        }
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        if (rb.velocity.x != 0)
        {
            //audioManager.WalkSound();
        }
        else
        {
           //audioManager.StopSFX(audioManager.walk);
        }
        animator.SetFloat("xVelocity",Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
       

    }
    void FlipSprite()
    {
        if(isFacingRight && horizontalInput <0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }
    public void ChangeHealth(int amount)
    {
        

        if (amount < 0) {
            audioManager.PlaySFX(audioManager.hurt);
            if (isInvincible)
                return;

            animator.SetTrigger("Hurt");
            

            isInvincible = true;
            invincibleTimer = timeInvincible;

        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        heartBar.setHealth(currentHealth);

        Debug.Log(currentHealth + "/" + maxHealth);
        if(currentHealth <= 0)
        {
            Die();
        }

    }
    public void Die()
    {
        
        deadscreen.SetActive(true);
        animator.SetTrigger("Dead");
        this.enabled = false;
    }
}
