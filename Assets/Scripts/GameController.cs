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
    public GameObject playerHealthBar;

    public Sprite[] phs;

    private void Start()
    {
        Time.timeScale = 1;
    }

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

        int playerHealth = player.GetComponent<playerscript>().health;

        playerHealthBar.GetComponent<Image>().sprite = phs[playerHealth];

        // made the healthbar code WAYYYY more effcient :)
    }
}
