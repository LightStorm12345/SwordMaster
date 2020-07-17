using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopUI : MonoBehaviour
{
    // we need the amount of money the player
    public GameObject player;
    public GameObject cantBuy;
    
    private int Money;

    private void Start()
    {
        Money = player.GetComponent<playerscript>().Money;
    }

    private void Update()
    {
        player.GetComponent<playerscript>().Money = Money;
    }

    public void PayForItem(int cost, int itemID)
    {
        if (Money - cost <= 0)
        {
            StartCoroutine(CantBuy());
        }
        else
        {
            
        }

    }

    IEnumerator CantBuy()
    {
        cantBuy.SetActive(true);
        yield return new WaitForSeconds(2);
        cantBuy.SetActive(false);
    }
}
