using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region Public Variable
    public Transform player;
    public bool isFlipped = false;
    
    #endregion
    #region Private Variables


    
    #endregion
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if(transform.position.x >player.position.x && isFlipped)
        {
            transform.localScale= flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x<player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            isFlipped = true;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
