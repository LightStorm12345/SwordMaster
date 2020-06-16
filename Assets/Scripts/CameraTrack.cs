using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public GameObject objectToFollow;
    public Vector3 offset;

    void Update()
    {
        gameObject.transform.position = objectToFollow.transform.position + offset;
    }
}
