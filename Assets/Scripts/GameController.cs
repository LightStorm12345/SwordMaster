using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text MoneyCounter;
    public GameObject player;
    public GameObject enemy;
    public GameObject pauseMenu;

    void Update()
    {
        // Gets the ammount of money the player has from the playerScript.cs script
        int playerMoney = player.GetComponent<playerscript>().Money;

        MoneyCounter.text = "$" + playerMoney.ToString();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(enemy);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

    }
}
