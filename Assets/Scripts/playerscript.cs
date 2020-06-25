using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public int Money;
    public int highValueCoinsWorth;
    public int lowValueCoinsWorth;
    // in later versions of the game have saved files for this type of stuff for now it just always starts with $0

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Coin01":
                Destroy(collision.gameObject);
                Money += highValueCoinsWorth;
                break;
            
            case "Coin02":
                Destroy(collision.gameObject);
                Money += lowValueCoinsWorth;
                break;

        }
    }
}
