using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamera : MonoBehaviour
{
    private StateTransform state;
    public GameObject attackScript;
    private void Awake()
    {
        state = GetComponentInParent<StateTransform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            state.camFinal.SetActive(true);
        }
    }
}
