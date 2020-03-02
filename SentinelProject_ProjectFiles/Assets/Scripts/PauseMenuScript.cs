using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseMenu;
    public GameObject GameOver;
    public GameObject Win;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetButtonDown("StartButton"))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        //this is a stand in for when player wins to test sene transitions
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //Win.SetActive(true);
        //Invoke("MainMenu", 16);
        //}
        //this is a stand in for when player looses to test scene transitions
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //GameOver.SetActive(true);
        //Invoke("MainMenu", 5);
        //}
    }

    public void Resume ()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    void Pause ()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
