﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementscript : MonoBehaviour
{
    public Transform trans;
    public Rigidbody2D rb;
    public float walkingSpeed;
    public float runningSpeed;

    public bool runByDefault;

    private float currentSpeed;

    void Update()
    {
        bool isRunning = false; // unity gets mad if I don't assign it, even tho is assigned later in the code, but what can I do about it, eh?

        if (runByDefault && Input.GetKey(KeyCode.LeftShift)) // check if the player runs by default and if the user pressed shift
        {
            isRunning = false;
        }
        else if (runByDefault && !Input.GetKey(KeyCode.LeftShift)) // check if the player runs by default and is not pressing shift
        {
            isRunning = true;
        }
        if (!runByDefault && Input.GetKey(KeyCode.LeftShift)) // check if the player doesnt run by default and is pressing shift
        {
            isRunning = true;
        }
        else if (!runByDefault && !Input.GetKey(KeyCode.LeftShift)) // check if hte player doesnt run by default and is not pressing shift
        {
            isRunning = false;
        }

        print(isRunning);

        if (isRunning)
        {
            currentSpeed = runningSpeed;
        }
        else
        {
            currentSpeed = walkingSpeed;
        }


        // move up or other ways (\ | /)
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.D))
            {
                trans.eulerAngles = new Vector3(0, 0, -45);
                rb.velocity = new Vector2(currentSpeed * Time.deltaTime * 0.5f, currentSpeed * Time.deltaTime * 0.5f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                trans.eulerAngles = new Vector3(0, 0, 45);
                rb.velocity = new Vector2(currentSpeed * -1 * Time.deltaTime * 0.5f, currentSpeed * Time.deltaTime * 0.5f);
            }
            else
            {
                trans.eulerAngles = new Vector3(0, 0, 0);
                rb.velocity = new Vector2(0, currentSpeed * Time.deltaTime);
            }

        }

        // move down or other ways (/ | \)
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.D))
            {
                trans.eulerAngles = new Vector3(0, 0, -135);
                rb.velocity = new Vector2(currentSpeed * Time.deltaTime * 0.5f, currentSpeed * -1 * Time.deltaTime * 0.5f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                trans.eulerAngles = new Vector3(0, 0, 135);
                rb.velocity = new Vector2(currentSpeed * -1 * Time.deltaTime * 0.5f, currentSpeed * -1 * Time.deltaTime * 0.5f);
            }
            else
            {
                trans.eulerAngles = new Vector3(0, 0, 180);
                rb.velocity = new Vector2(0, currentSpeed * -1 * Time.deltaTime);
            }
        }

        // make sure w and s are not pressed before moving left or right
        // (- o -)
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            trans.eulerAngles = new Vector3(0, 0, 90);
            rb.velocity = new Vector2(currentSpeed * -1 * Time.deltaTime, 0);
        }

        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            trans.eulerAngles = new Vector3(0, 0, -90);
            rb.velocity = new Vector2(currentSpeed * Time.deltaTime, 0);
        }

        // if all movement keys are released then set velocity to 0
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}