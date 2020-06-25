using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    public int lerpSpeed;

    private void Update()
    {
        // linear interpolation to the player

        GameObject player = GameObject.FindWithTag("Player");

        gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, player.transform.position, lerpSpeed * 3.0f * Time.deltaTime);
    }
}
