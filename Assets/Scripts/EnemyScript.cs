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
    public int minNumberOfCoins;
    public int maxNumberOfCoins;

    public GameObject healthbar;


    public int health = 10;
    // DO NOT CHANGE THIS!!!
    // FOR NOW THIS IS PERMANENT

    public Sprite hl1;
    public Sprite hl2;
    public Sprite hl3;
    public Sprite hl4;
    public Sprite hl5;
    public Sprite hl6;
    public Sprite hl7;
    public Sprite hl8;
    public Sprite hl9;
    public Sprite hl10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // the collider tag is equal to "Sword" then reduce the health
        if (collision.tag == "Sword")
        {
            health = health - 1;
        }
    }

    private void Update()
    {
        SpriteRenderer spriteRender = healthbar.GetComponent<SpriteRenderer>();

        switch (health)
        {
            case 10:
                spriteRender.sprite = hl10;
                break;
            case 9:
                spriteRender.sprite = hl9;
                break;
            case 8:
                spriteRender.sprite = hl8;
                break;
            case 7:
                spriteRender.sprite = hl7;
                break;
            case 6:
                spriteRender.sprite = hl6;
                break;
            case 5:
                spriteRender.sprite = hl5;
                break;
            case 4:
                spriteRender.sprite = hl4;
                break;
            case 3:
                spriteRender.sprite = hl3;
                break;
            case 2:
                spriteRender.sprite = hl2;
                break;
            case 1:
                spriteRender.sprite = hl1;
                break;
        }


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
            }
            // we are done generating coins, remove the enemy
            Destroy(gameObject);
        }
    }
}
