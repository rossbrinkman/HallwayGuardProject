using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Keypad : MonoBehaviour
{
    public Text number0;
    public Text number1;
    public Text number2;
    public Text number3;
    public Text number4;
    public Text number5;
    public Text invalidCodeText;
    public Text beginTypingText;
    public Text invalidInputText;
    public Image indicator;
    public GameObject Win;
    public GameObject GameOverScreen;
    public GameObject player;

    bool timeUp;
    bool switchFinished;
    bool playedOnce = false;
    public static bool gameOver;

    private int attemptsLeft;
    private int codeNumber;
    private int currentInt = 15;
    private bool inTrigger = false;



    // Start is called before the first frame update
    void Start()
    {
        attemptsLeft = 3;
        codeNumber = -1;
        invalidInputText.text = "";
        beginTypingText.text = "";
        invalidCodeText.text = "";
        number0.text = "";
        number1.text = "";
        number2.text = "";
        number3.text = "";
        number4.text = "";
        number5.text = "";

        gameOver = false;
        switchFinished = false;
        timeUp = false;
        StartCoroutine(Blink());

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (timeUp)
            {
                timeUp = false;
                StartCoroutine(Blink());
            }

            if (inTrigger)
            {
                PlayerInput();
                SetCodeNumber();
                SetIndicator();
            }

            if (switchFinished)
            {
                CheckCode();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            beginTypingText.text = "Begin typing...";
            inTrigger = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Escape))
                { }
                else { beginTypingText.text = ""; }

            }
            else
            {

            }

            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            beginTypingText.text = "";
            inTrigger = false;
        }
    }

    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            invalidInputText.text = "";
            currentInt = 0;
            codeNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            invalidInputText.text = "";
            currentInt = 1;
            codeNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            invalidInputText.text = "";
            currentInt = 2;
            codeNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            invalidInputText.text = "";
            currentInt = 3;
            codeNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            invalidInputText.text = "";
            currentInt = 4;
            codeNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            invalidInputText.text = "";
            currentInt = 5;
            codeNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            invalidInputText.text = "";
            currentInt = 6;
            codeNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
        {
            invalidInputText.text = "";
            currentInt = 7;
            codeNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            invalidInputText.text = "";
            currentInt = 8;
            codeNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            invalidInputText.text = "";
            currentInt = 9;
            codeNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            invalidInputText.text = "";
            currentInt = 15;
            if (codeNumber > -1 && codeNumber <= 5)
                codeNumber--;
            else if (codeNumber > 5)
                codeNumber = 4;
            else
                codeNumber = -1;
        }
        else if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)
                || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3) ||
            Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5)
            || Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7) ||
            Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
            {

            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace)) { }
            else
            {
                invalidInputText.text = "Invalid Input. Numbers only.";
                FindObjectOfType<AudioManager>().Play("Denied");

            }
        }
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(.5f);

        if (indicator.enabled)
        {
            indicator.enabled = false;
            timeUp = true;
        }
        else
        {
            indicator.enabled = true;
            timeUp = true;
        }

    }

    void SetIndicator()
    {
        if (codeNumber == -1)
            indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, -81.83f);
        if (codeNumber == 0)
            indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, -81.139f);
        if (codeNumber == 1)
            indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, -80.475f);
        if (codeNumber == 2)
            indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, -79.808f);
        if (codeNumber == 3)
            indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, -79.121f);
        if (codeNumber == 4)
            indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, -78.418f);

    }

    void CheckCode()
    {
        if (number0.text == "9" && number1.text == "3" && number2.text == "1" && number3.text == "6" && number4.text == "4" && number5.text == "7" && attemptsLeft > 0)
        {
            invalidCodeText.text = "Access Granted.";
            FindObjectOfType<AudioManager>().Play("Correct");
            invalidCodeText.color = Color.green;
            FindObjectOfType<AudioManager>().Stop("Music");
            GameObject[] ais = GameObject.FindGameObjectsWithTag("AI");
            //foreach (GameObject gameobject in ais)
            //{
            //    gameobject.GetComponent<AudioSource>().mute = true;
            //}
            FindObjectOfType<AudioManager>().Play("Win");
            player.GetComponent<CharacterController>().enabled = false;
            gameOver = true;
            Win.SetActive(true);
            Invoke("MainMenu", 16);
        }
        else
        {
            attemptsLeft--;

            if (attemptsLeft > 0)
            {
                print("not correct");

                codeNumber = -1;
                currentInt = 15;
                number0.text = "";
                number1.text = "";
                number2.text = "";
                number3.text = "";
                number4.text = "";
                number5.text = "";

                switchFinished = false;

                invalidCodeText.text = "Invalid Code. Attempts remaining: " + attemptsLeft;
                FindObjectOfType<AudioManager>().Play("Denied");
                indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, -81.83f);
            }
            else
            {
                invalidCodeText.text = "0 Attempts Remaining. Access Locked.";
                if (!playedOnce)
                {
                    FindObjectOfType<AudioManager>().Play("Denied");
                    playedOnce = true;
                }

                FindObjectOfType<AudioManager>().Stop("Music");
                GameObject[] ais = GameObject.FindGameObjectsWithTag("AI");
                //foreach (GameObject gameobject in ais)
                //{
                //    gameobject.GetComponent<AudioSource>().mute = true;
                //}
                FindObjectOfType<AudioManager>().Play("Lose");
                gameOver = true;
                player.GetComponent<CharacterController>().enabled = false;
                GameOverScreen.SetActive(true);
                Invoke("MainMenu", 6);
            }

        }
    }


    void SetCodeNumber()
    {
        if (currentInt != 15)
        {
            switch (codeNumber)
            {
                case 0:
                    number0.text = currentInt.ToString();

                    break;
                case 1:
                    number1.text = currentInt.ToString();

                    break;
                case 2:
                    number2.text = currentInt.ToString();

                    break;
                case 3:
                    number3.text = currentInt.ToString();

                    break;
                case 4:
                    number4.text = currentInt.ToString();

                    break;
                case 5:
                    number5.text = currentInt.ToString();
                    switchFinished = true;
                    break;
            }
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
