using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deadscreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {

            deadscreen.SetActive(true);
           
            Destroy(collision.gameObject);
        }
                

    }
}
