using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepAudio : MonoBehaviour
{
    public GameObject footstep;

    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            footsteps();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            footsteps();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            stopfootstep();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            stopfootstep();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stopfootstep();
        }
    }
    void footsteps()
    {
        footstep.SetActive(true);
    }
    void stopfootstep() 
    { 
        footstep.SetActive(false);
    }
    
}
