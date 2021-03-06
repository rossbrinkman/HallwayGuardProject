﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public AudioSource soundSource;
    public AudioClip walking;
    public float speed;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

       

        //Debug.Log("X: " + x);
        //Debug.Log("Z: " + z);
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(x == 0 && z == 0 && !PauseMenuScript.GamePaused)
        {
            
            soundSource.clip = walking;
            soundSource.Play();
        }

        if (PauseMenuScript.GamePaused || Keypad.gameOver)
        {
            soundSource.mute = true;
        }
        else
        {
            soundSource.mute = false;
        }
        

    }

     

}
