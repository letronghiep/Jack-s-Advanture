using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int dame = 20;
    void OnTriggerStay2D(Collider2D other)
    {
        move controller = other.GetComponent<move>();

        if (controller != null)
        {
            controller.ChangeHealth(-dame);
        }
    }
}
