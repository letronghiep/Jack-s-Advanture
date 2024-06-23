using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTrigger trigger;
    
    public bool isConversation=false;

    public GameObject icon;
    public GameObject notice;
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            isConversation = true;
            icon.SetActive(true);
            notice.SetActive(true);
        }
            

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            isConversation = false;
            icon.SetActive(false);
            notice.SetActive(false);
        }
            
    }
    private void Update()
    {
        if (isConversation && Input.GetKeyDown(KeyCode.E))
        {
            trigger.StartDialogue();
         
        }
    }
}
