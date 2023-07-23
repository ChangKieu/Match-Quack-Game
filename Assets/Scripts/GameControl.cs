using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{
    public AudioSource love, hate;
    bool dead,win;
    public GameObject gameover,lv;
    Duck duck;
    Duck2 duck2;
    int dem;
    public int max;
    private void Start()
    {
        win = false;
        dead= false;
        dem = 0;
        duck= FindObjectOfType<Duck>();
        duck2 = FindObjectOfType<Duck2>();
    }
    private void Update()
    {
        if(dead && gameover.activeSelf ==false)
        {
            
            Invoke("ShowGO", (float)0.5);
            return;
        }
        if(win && lv.activeSelf==false)
        {
            
            Invoke("ShowLVUp", (float)0.7);
            return;
        }
    }
    public void ShowGO()
    {
        gameover.SetActive(true);
    }
    public void ShowLVUp()
    { 
        lv.SetActive(true); 
    }
    public bool IsDead()
    { 
        return dead; 
    }
    public void SetGameover(bool state)
    {
        dead = state;
        if(dead)
        {
            hate.Play();
        }
    }
    public void IsTrue()
    {
        dem++;
        if(dem==max)
        {
            win= true;
            love.Play();
        }
    }
    public void Replay()
    {
        gameover.SetActive(false);
        lv.SetActive(false);
        win= false;
        dead = false;
        dem = 0;
        duck.SetStart();
        duck2.SetStart();
    }
}
