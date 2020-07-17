using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public int Money;
    public int highValueCoinsWorth;
    public int lowValueCoinsWorth;
    public int healthKitBuff;

    public int health;

    public int healthDamage;

    public GameObject deathScreen;


    public int currSprite = 0;
    // 0 = idle
    // 1 = Sword Spin

    public SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite swordSpinSprite;


    // in later versions of the game have saved files for this type of stuff for now it just always starts with $0

    private void Update()
    {

        switch (currSprite)
        {
            case 0:
                spriteRenderer.sprite = idleSprite;
                break;
            case 1:
                spriteRenderer.sprite = swordSpinSprite;
                break;
        }

        if (health == 0)
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            // When detecting coin01
            case "Coin01":
                Destroy(collision.gameObject);
                Money += highValueCoinsWorth;
                break;
            
            // when detecting coin02
            case "Coin02":
                Destroy(collision.gameObject);
                Money += lowValueCoinsWorth;
                break;

            case "HealthKit":
                Destroy(collision.gameObject);
                health += healthKitBuff;
                health = Mathf.Clamp(health, 0, 10);
                break;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            health -= healthDamage;
        }
    }
}
