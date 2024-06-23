using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform swordPoint;
    public Animator animator;
    public GameObject swordPrefab;
    float reset;
    public AudioSource audio;
    public float cooldown = 5;
    bool isCooldown = false;
    void Start()
    {
        reset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K) && isCooldown==false)
        {
            audio.Play();
            isCooldown = true;
            reset = cooldown;
            animator.SetTrigger("Skill");
            SwordSkill();

        }
        if (isCooldown)
        {
            reset-=Time.deltaTime;
            if(reset<=0)
            {
                reset = 0;
                isCooldown = false;
            }
        }
    }
    void SwordSkill()
    {
        Instantiate(swordPrefab, swordPoint.position, swordPoint.rotation);
    }
}
