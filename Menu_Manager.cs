using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class Menu_Manager : MonoBehaviour
{
    public GameObject panel;
    float opentime ;
    public GameObject menu;
    public GameObject levels;
    // Start is called before the first frame update
    void Start()
    {
        
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });


        panel = GameObject.FindGameObjectWithTag("Game_Open");
        menu = GameObject.FindGameObjectWithTag("Menu");
        levels = GameObject.FindGameObjectWithTag("Levels");
        opentime = Time.time;

        levels.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - opentime >= 1f)
        {
            panel.GetComponent<Image>().raycastTarget = false;
        }
        
    }

    public void play()
    {
        menu.SetActive(false);
        levels.SetActive(true);
    }
    public void BackToMenu()
    {
        menu.SetActive(true);
        panel.GetComponent<Image>().raycastTarget = true;
        opentime = Time.time;
        levels.SetActive(false);
    }

 
    public void exit()
    {
        Application.Quit();
        
    }
    public void lvl0()
    {
        SceneManager.LoadScene(1);
    }
    public void lvl1()
    {
        SceneManager.LoadScene(2);
    }
    public void lvl2()
    {
        SceneManager.LoadScene(3);
    }
    public void lvl3()
    {
        SceneManager.LoadScene(4);
    }
    public void lvl4()
    {
        SceneManager.LoadScene(5);
    }
    public void lvl5()
    {
        SceneManager.LoadScene(6);
    }
    public void lvl6()
    {
        SceneManager.LoadScene(7);
    }
    public void lvl7()
    {
        SceneManager.LoadScene(8);
    }
    public void lvl8()
    {
        SceneManager.LoadScene(9);
    }
    public void lvl9()
    {
        SceneManager.LoadScene(10);
    }
    public void lvl10()
    {
        SceneManager.LoadScene(11);
    }

}
