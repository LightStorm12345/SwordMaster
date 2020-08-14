using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SocialPlatforms;

public class EnemyScript : MonoBehaviour
{
    public GameObject highValueCoin;
    public GameObject lowValueCoin;
    public GameObject healthKit;

    public int minNumberOfCoins;
    public int maxNumberOfCoins;

    public GameObject healthbar;

    public int chanceOfDroppingHealthKit;


    public int health = 10;
    // DO NOT CHANGE THIS!!!
    // FOR NOW THIS IS PERMANENT

    public Sprite[] hls;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // the collider tag is equal to "Sword" then reduce the health
        if (collision.tag == "Sword")
        {
            health = health - 1;
        }
        if (collision.tag == "Shuriken")
        {
            health = health - 1;
            collision.gameObject.GetComponent<AttackScript>().DestroyThrowable();
        }
    }

    private void Update()
    {
        SpriteRenderer spriteRender = healthbar.GetComponent<SpriteRenderer>();

        // I made the healthbar code WAYYYY more efficient :)

        spriteRender.sprite = hls[Mathf.Clamp(health-1, 0, 9)];


        // if the health is equal to 0, spawn coins
        if (health == 0)
        {
            // drop coins
            for (int i = 0; i < Random.Range(minNumberOfCoins, maxNumberOfCoins); i++)
            {
                // generate a random number (1 or 2)
                int rng = Random.Range(1, 3);
                
                // where the coins can spawn
                Vector3 offset = new Vector3(Random.Range(-3, 4), Random.Range(-3, 4), 0);
                
                // Spawn coins randomly around the dead enemy
                offset += gameObject.transform.position;
                
                // I made the code more efficient :)
                switch (rng)
                {
                    case 1:
                        // high value coin
                        GameObject HVC = Instantiate(highValueCoin);
                        HVC.transform.position = offset;
                        break;
                    
                    case 2:
                        // low value coin
                        GameObject LVC = Instantiate(lowValueCoin);
                        LVC.transform.position = offset;
                        break;

                }
                rng = Random.Range(1, 10);

                if (rng <= chanceOfDroppingHealthKit)
                {
                    GameObject hk = Instantiate(healthKit);
                    hk.transform.position = offset;
                }

            }
            // we are done generating coins, remove the enemy
            Destroy(gameObject);
        }
    }
}
