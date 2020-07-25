using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]

public class FixAnimationNotPlayLocal : MonoBehaviour
{
    Vector3 localPos;
    bool wasPlaying;

    void Awake()
    {
        localPos = transform.position;
        wasPlaying = false;
    }

    void LateUpdate()
    {
        if (!GetComponent<Animation>().isPlaying != !wasPlaying)
            return;

        transform.localPosition += localPos;

        wasPlaying = GetComponent<Animation>().isPlaying;
    }
}
