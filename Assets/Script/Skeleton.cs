using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    #region Public Variable
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    #endregion
    #region Private Variables


    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool cooling;
    private float intTimer;
    #endregion
    private void Awake()
    {
        SelectTarget();
        intTimer = timer;
        
        anim =GetComponent<Animator>();
    }
   

    void Update()
    {
        if (!attackMode)
        {
            Move();
        }
        if(!InideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            SelectTarget();
        }


        if (inRange)
        {
            EnemyLogic();
        }
    }
    
    void EnemyLogic()
    {
        distance=Vector2.Distance(transform.position,target.position);
        if (distance > attackDistance)
        {

            StopAttack();

        }else if(attackDistance>=distance && cooling==false)
        {
            Attack();
        }
        if (cooling)
        {
            CoolDown();
            anim.SetBool("Attack", false);
        }
    }
    void Move()
    {
        anim.SetBool("isWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position=Vector2.MoveTowards(transform.position,targetPosition,moveSpeed*Time.deltaTime);
        }
    }
    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        anim.SetBool("isWalk", false);
        anim.SetBool("Attack", true);
    }
    void CoolDown()
    {
        timer-=Time.deltaTime;
        if(timer<=0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    void StopAttack()
    {
        cooling=false;
        attackMode=false;
        anim.SetBool("Attack", false);
    }
 

    public void TriggerCooling()
    {
        cooling = true;
    }
    private bool InideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }
    public void SelectTarget()
    {
        float distanceToLeft= Vector2.Distance(transform.position,leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }
        Flip();
    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles=rotation;

    }
    
}
