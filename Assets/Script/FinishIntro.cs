using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishIntro : MonoBehaviour
{
    [SerializeField] bool goNextScreen;
    [SerializeField] string screenName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
              
                SceneController.instance.NextLevel();
            
                
           
        }
    }
   
}
