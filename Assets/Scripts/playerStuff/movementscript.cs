using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementscript : MonoBehaviour
{
    public Transform trans;
    public Rigidbody2D rb;
    public Transform objectHolder;

    public float walkingSpeed;
    public float runningSpeed;

    public float editorWalkingSpeed;
    public float editorRunningSpeed;

    public bool runByDefault;

    private float currentSpeed;

    public Sprite[] playerSprites;
    // 0 - forward
    // 1 - backwards
    // 2 - sides

    private void Start()
    {
        // for some odd reason the rest of the code runs perfect on stand alone
        // but eh what can I do?
        if (Application.isEditor)
        {
            walkingSpeed = editorWalkingSpeed;
            runningSpeed = editorRunningSpeed;
        }
    }



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


        if (isRunning)
        {
            currentSpeed = runningSpeed;
        }
        else
        {
            currentSpeed = walkingSpeed;
        }

        currentSpeed = currentSpeed * Time.deltaTime;

        // move up or other ways (\ | /)
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            trans.GetChild(0).transform.eulerAngles = new Vector3(0, 0, 0);
            if (objectHolder.childCount > 0)
            {
                objectHolder.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 0;
            }

            if (Input.GetKey(KeyCode.D))
            {
                //trans.eulerAngles = new Vector3(0, 0, -45);
                rb.velocity = new Vector2(currentSpeed * 0.5f, currentSpeed * 0.5f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                //trans.eulerAngles = new Vector3(0, 0, 45);
                rb.velocity = new Vector2(currentSpeed * -1 * 0.5f, currentSpeed * 0.5f);
            }
            else
            {
                //trans.eulerAngles = new Vector3(0, 0, 0);
                rb.velocity = new Vector2(0, currentSpeed);
            }

        }

        // move down or other ways (/ | \)
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[1];
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            trans.GetChild(0).transform.eulerAngles = new Vector3(0, 0, 180);
            
            if (objectHolder.childCount > 0)
            {
                objectHolder.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 99;
            }

            if (Input.GetKey(KeyCode.D))
            {
                //trans.eulerAngles = new Vector3(0, 0, -135);
                rb.velocity = new Vector2(currentSpeed * 0.5f, currentSpeed * -1 * 0.5f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                //trans.eulerAngles = new Vector3(0, 0, 135);
                rb.velocity = new Vector2(currentSpeed * -1 * 0.5f, currentSpeed * -1 * 0.5f);
            }
            else
            {
                //trans.eulerAngles = new Vector3(0, 0, 180);
                rb.velocity = new Vector2(0, currentSpeed * -1);
            }
        }

        // make sure w and s are not pressed before moving left or right
        // (- o -)
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[2];
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            trans.GetChild(0).transform.eulerAngles = new Vector3(0, 180, -90);
            if (objectHolder.childCount > 0)
            {
                objectHolder.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 99;
            }

            //trans.eulerAngles = new Vector3(0, 0, 90);
            rb.velocity = new Vector2(currentSpeed * -1, 0);
        }

        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[2];
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            trans.GetChild(0).transform.eulerAngles = new Vector3(0, 0, -90);
            if (objectHolder.childCount > 0)
            {
                objectHolder.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 0;
            }

            //trans.eulerAngles = new Vector3(0, 0, -90);
            rb.velocity = new Vector2(currentSpeed, 0);
        }

        // if all movement keys are released then set velocity to 0
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
