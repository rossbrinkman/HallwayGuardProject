using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    public GameObject GameOverScreen;
    public GameObject player;

    void Start()
    {
        mainTimer = 180f;
        timer = mainTimer;
    }

    void Update()
    {
        if (!Keypad.gameOver)
        {
            if (timer >= 0.0f && canCount)
            {
                timer -= Time.deltaTime;
                uiText.text = timer.ToString("F");
            }

            else if (timer <= 0.0f && !doOnce)
            {
                canCount = false;
                doOnce = true;
                uiText.text = "0.00";
                timer = 0.0f;
                GameOver();
            }
        }
    }


    void GameOver()
    {
        // Load a game over screen
        FindObjectOfType<AudioManager>().Stop("Music");
        GameObject[] ais = GameObject.FindGameObjectsWithTag("AI");
        foreach (GameObject gameobject in ais)
        {
            gameobject.GetComponent<AudioSource>().mute = true;
        }
        FindObjectOfType<AudioManager>().Play("Lose");
        player.GetComponent<CharacterController>().enabled = false;
        GameOverScreen.SetActive(true);
        Invoke("MainMenu", 6);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

















































    /*
    public int hoursLeft;
    public int secondsLeft;
    public int minutesLeft;
    public float secondFractionsLeft;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        hoursLeft = 0;
        minutesLeft = 1;
        secondsLeft = 59;
        secondFractionsLeft = .99f;
        //timerText.text = timeLeft.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        //timerText.text = timeLeft.ToString("F2");
        secondFractionsLeft -= Time.deltaTime;

        //if (secondFractionsLeft <= 0 && secondsLeft == 0 && minutesLeft == 0 && hoursLeft == 0)
        //{
        //    print("Game Over");
        //}
        //else
        //{
        //    print(hoursLeft + " : " + minutesLeft + " : " + secondsLeft + " : " + secondFractionsLeft.ToString("F2"));
        //}

        if (secondFractionsLeft < 0 && secondsLeft != 0)
        {
            secondFractionsLeft = .99f;
            secondsLeft--;
        }

        if (secondsLeft < 0 && minutesLeft != 0)
        {
            secondsLeft = 59;
            minutesLeft--;
        }

        if (minutesLeft < 0 && hoursLeft != 0)
        {
            minutesLeft = 59;
            hoursLeft--;
        }

    }*/
}
