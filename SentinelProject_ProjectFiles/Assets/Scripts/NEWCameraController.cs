//New Camera controller using Euler Angles. Should lock at 90 degrees up and 45 degrees down.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWCameraController : MonoBehaviour
{
    public float mouseSensitvity;

    public Transform playerBody;

    float xRotation = 0f;

    private bool pause = false;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseCont();
        stickCont();
    }

    void mouseCont()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitvity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitvity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        /*if (Input.GetKeyDown("p") && pause == false)
        {
            Debug.Log("Game 'paused.'");
            Cursor.lockState = CursorLockMode.None;
            pause = true;
        }

        if (Input.GetKeyDown("p") && pause == true)
        {
            Debug.Log("Game 'unpaused.'");
            Cursor.lockState = CursorLockMode.Locked;
            pause = false;
        }*/
    }

    void stickCont()
    {
        float mouseX = Input.GetAxis("R_JoyStickHor") * (mouseSensitvity*10) * Time.deltaTime;
        float mouseY = Input.GetAxis("R_JoyStickVert") * (mouseSensitvity*10) * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        /*if (Input.GetKeyDown("p") && pause == false)
        {
            Debug.Log("Game 'paused.'");
            Cursor.lockState = CursorLockMode.None;
            pause = true;
        }

        if (Input.GetKeyDown("p") && pause == true)
        {
            Debug.Log("Game 'unpaused.'");
            Cursor.lockState = CursorLockMode.Locked;
            pause = false;
        }*/
    }
}
