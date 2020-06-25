using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text MoneyCounter;
    public GameObject player;

    void Update()
    {
        // Gets the ammount of money the player has from the playerScript.cs script
        int playerMoney = player.GetComponent<playerscript>().Money;

        MoneyCounter.text = "$" + playerMoney.ToString();
    }
}
