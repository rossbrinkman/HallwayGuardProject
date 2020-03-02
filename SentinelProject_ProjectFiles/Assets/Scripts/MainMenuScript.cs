using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame ()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditsScreen()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
