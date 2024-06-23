using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Boss_run : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    public float timer;
    public float minTime;
    public float maxTime;
    private int rand;
    Transform player;
    Rigidbody2D rb;
    Boss boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer=Random.Range(minTime, maxTime);
       player= GameObject.FindGameObjectWithTag("Player").transform;
        rb=animator.GetComponent<Rigidbody2D>();
        boss=animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(timer <= 0)
        {
            animator.SetTrigger("Idle");
        }
        else
        {
            timer-= Time.deltaTime;
        }
        boss.LookAtPlayer();
        Vector2 target=new Vector2(player.position.x,rb.position.y);
        Vector2 newPos= Vector2.MoveTowards(rb.position,target,speed*Time.deltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            
            rand = Random.Range(0, 2);

            if (rand == 0)
            {
                animator.SetTrigger("Attack");
            }
            else
            {
                animator.SetTrigger("EnragedAttack");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    
}
