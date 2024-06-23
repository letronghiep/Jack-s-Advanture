using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectChapter : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        int unlockLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = -1; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = -1;i < unlockLevel;i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void OpenChapter(string chapterName)
    {
        
        SceneManager.LoadScene(chapterName);
    }
}
