using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerOld : MonoBehaviour
{
    public float speed;

    private bool pause = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();

      
    }

    // Update is called once per frame
    void Update()
    {
        KeyCont();
        StickCont();
        
    }

    void KeyCont()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;

        

        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);
        Debug.Log("Movement Forward: " + translation);
        Debug.Log("Movement Side: " + strafe);
        if (Input.GetKeyDown("escape") && pause == false)
        {
            Debug.Log("Game 'paused.'");
            Cursor.lockState = CursorLockMode.None;
            pause = true;
        }

        if (Input.GetKeyDown("escape") && pause == true)
        {
            Debug.Log("Game 'unpaused.'");
            Cursor.lockState = CursorLockMode.Locked;
            pause = false;
        }

    }

    void StickCont()
    {

        float translation = Input.GetAxis("L_JoyStickVert") * speed;
        float strafe = Input.GetAxis("L_JoyStickHor") * speed;

        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        if (Input.GetButtonDown("StartButton") && pause == false)
        {
            Debug.Log("Game 'paused.'");
            Cursor.lockState = CursorLockMode.None;
            pause = true;
        }

        else if (Input.GetButtonDown("StartButton") && pause == true)
        {
            Debug.Log("Game 'unpaused.'");
            Cursor.lockState = CursorLockMode.Locked;
            pause = false;
        }

    }
}
