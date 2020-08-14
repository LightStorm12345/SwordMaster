using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float enemyMoveSpeed;
    public float stopDistance;
    public float triggerRadius;

    public bool isFollowingPlayer;

    public Transform player;
    public Transform enemyGFX;

    private void OnDrawGizmosSelected() // show the trigger radius when selected
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }

    private void Awake()  // if the enemy was generated (so it saves Find calls)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = Vector2.MoveTowards(transform.position, player.position, 0.01f);
    }

    private void Update()
    {
        var heading = player.position - transform.position;

        if (heading.sqrMagnitude < triggerRadius * triggerRadius) // check if the enemy was triggered
        {
            isFollowingPlayer = true;
        }

        if (heading.sqrMagnitude > stopDistance * stopDistance && isFollowingPlayer)  // more efficent way to get distance
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * enemyMoveSpeed);

            enemyGFX.up = player.position - transform.position;

        }
    }
}
