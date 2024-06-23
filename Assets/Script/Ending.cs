using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public Animator transition;
    public int index;
    public float transitionTime = 1f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextScreen();
        }
    }
    public void LoadNextScreen()
    {
        StartCoroutine(LoadLevel(index));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
