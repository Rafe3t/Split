using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public GameObject GUI;
    public GameObject Pause_Menu;
    public GameObject Level_Completed;
    public GameObject Game_Over;

    // Start is called before the first frame update
    void Start()
    {
        GUI = GameObject.Find("GUI");
        Pause_Menu = GameObject.Find("Pause_Menu");
        Level_Completed = GameObject.Find("Level_Completed");
        Game_Over = GameObject.Find("Game_Over");

        GUI.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(pause);
        Level_Completed.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(return_menu);
        Level_Completed.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(next_level);
        Pause_Menu.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(resume);
        Pause_Menu.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(return_menu);
        Pause_Menu.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(retry);
        Game_Over.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(retry);
        Game_Over.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(return_menu);


        Pause_Menu.SetActive(false);
        Level_Completed.SetActive(false);
        Game_Over.SetActive(false);
    }

    public void resume()
    {
        GUI.SetActive(true);
        Pause_Menu.SetActive(false);
        Level_Completed.SetActive(false);
        Game_Over.SetActive(false);
        Time.timeScale = 1;
    }

    public void pause()
    {
        GUI.SetActive(false);
        Pause_Menu.SetActive(true);
        Level_Completed.SetActive(false);
        Game_Over.SetActive(false);
        Time.timeScale = 0;

    }

    public void complete_level()
    {
        GUI.SetActive(false);
        Pause_Menu.SetActive(false);
        Level_Completed.SetActive(true);
        Game_Over.SetActive(false);
    }

    public void gameover()
    {
        GUI.SetActive(false);
        Pause_Menu.SetActive(false);
        Level_Completed.SetActive(false);
        Game_Over.SetActive(true);
    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void next_level()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 != 12)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void return_menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
