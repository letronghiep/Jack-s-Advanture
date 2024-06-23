using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour
{
    [Header("Skill")]
    public Image skillImage;
    public float cooldown = 5;
    bool isCooldown=false;
    public KeyCode key;
    private void Start()
    {
        skillImage.fillAmount = 0;
    }
    private void Update()
    {
        Skill();
    }
    void Skill()
    {
        if(Input.GetKey(key)&& isCooldown == false)
        {
            isCooldown = true;
            skillImage.fillAmount = 1;
        }
        if (isCooldown)
        {
            skillImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            if(skillImage.fillAmount <= 0)
            {
                skillImage.fillAmount = 0;
                isCooldown=false;
            }
        } 
    }


}
