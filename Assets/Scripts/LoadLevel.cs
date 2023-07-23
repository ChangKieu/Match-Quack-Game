using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public Button[] buttons;
    public AudioSource click;
    private void Awake()
    {
        int unlock = PlayerPrefs.GetInt("unlock", 1);
        for(int i=0 ; i < buttons.Length ; i++)
        {
            buttons[i].interactable = false;
        }
        for(int i=0;i<unlock;i++)
        {
            buttons[i].interactable = true;
        }

    }
    public void OpenLevel(int level)
    {
        click.Play();
        string lv = "LV " + level;
        SceneManager.LoadScene(lv);
    }
}
