using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnHeart : MonoBehaviour
{
    public GameObject heart;
    private GameObject currentHeart;
    private bool isSpawning = false;
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHeart==null && !isSpawning)
        {
            StartCoroutine(SpawnHeartAfterDelay(2f));
        }
    }
    void spawn() 
    {
        currentHeart= Instantiate(heart, transform.position, Quaternion.identity);
    }
    IEnumerator SpawnHeartAfterDelay(float delay)
    {
        isSpawning = true;
        yield return new WaitForSeconds(delay);

        spawn();
        isSpawning = false;
    }
}
