using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZone : MonoBehaviour
{
    private Skeleton enemyParent;
    private bool inRange;
    private Animator anim;

    private void Awake()
    {
        enemyParent= GetComponentInParent<Skeleton>();
        anim = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            enemyParent.Flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();
        }
    }

}

