using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PanelStart : MonoBehaviour
{
    public AudioSource click; 

    public void OpenLevelPanel()
    {
        SceneManager.LoadScene("LevelPanel");
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void UnlockNewLV()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("unlock", PlayerPrefs.GetInt("unlock", 1) + 1);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
