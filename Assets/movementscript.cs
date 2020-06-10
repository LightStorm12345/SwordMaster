using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementscript : MonoBehaviour
{
    public Transform trans;
    private int currRot;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.D))
            {
                trans.eulerAngles = new Vector3(0, 0, -45);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                trans.eulerAngles = new Vector3(0, 0, 45);
            }
            else
            {
                trans.eulerAngles = new Vector3(0, 0, 0);
            }

        }

        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.D))
            {
                trans.eulerAngles = new Vector3(0, 0, -135);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                trans.eulerAngles = new Vector3(0, 0, 135);
            }
            else
            {
                trans.eulerAngles = new Vector3(0, 0, 180);
            }
        }

        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            trans.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            trans.eulerAngles = new Vector3(0, 0, -90);
        }
    }
}
