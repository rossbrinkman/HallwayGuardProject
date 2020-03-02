using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    bool timeUp;
    bool switchFinished;

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

        switchFinished = false;
        timeUp = false;
        StartCoroutine(Blink());

    }

    // Update is called once per frame
    void Update()
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

        if(switchFinished)
        {
            CheckCode();
        }

    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            beginTypingText.text = "Begin typing to\n insert 6 digit code.";
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
        else if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)
                || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3) ||
            Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5)
            || Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7) ||
            Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
            {

            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Escape)) { }
            else
            {
                invalidInputText.text = "Invalid Input. Numbers only.";
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
        if (number0.text == "9" && number1.text == "3" && number2.text == "1" && number3.text == "6" && number4.text == "4" && number5.text == "7")
        {
            invalidCodeText.text = "Access Granted.";
            invalidCodeText.color = Color.green;
            //FindObjectOfType<AudioManager>().Play("Win"); [music not working]
           // FindObjectOfType<AudioManager>().Stop("Music");

            // GO TO WIN SCREEN
            // DO WINNERY STUFF
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
                indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, -81.83f);
            }
            else {
                invalidCodeText.text = "0 Attempts Remaining. Access Locked.";
              //  FindObjectOfType<AudioManager>().Play("Lose");
             //   FindObjectOfType<AudioManager>().Stop("Music");
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
                    //indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, indicator.transform.position.z + .691f);
                    break;
                case 1:
                    number1.text = currentInt.ToString();
                    //indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, indicator.transform.position.z + .664f);
                    break;
                case 2:
                    number2.text = currentInt.ToString();
                    //indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, indicator.transform.position.z + .667f);
                    break;
                case 3:
                    number3.text = currentInt.ToString();
                    //indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, indicator.transform.position.z + .687f);
                    break;
                case 4:
                    number4.text = currentInt.ToString();
                    //indicator.transform.position = new Vector3(indicator.transform.position.x, indicator.transform.position.y, indicator.transform.position.z + .703f);
                    break;
                case 5:
                    number5.text = currentInt.ToString();
                    switchFinished = true;
                    break;
            }
        }
    }

}
