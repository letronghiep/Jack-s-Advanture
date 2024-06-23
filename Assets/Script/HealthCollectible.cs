using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioSource audio;
    void OnTriggerEnter2D(Collider2D other)
    {
        move controller = other.GetComponent<move>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                audio.Play();
                controller.ChangeHealth(50);
                Destroy(gameObject);
            }
        }
    }
}
