using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopUI : MonoBehaviour
{
    // we need the amount of money the player
    public GameObject player;
    public GameObject cantBuy;
    public itemIDSystem itemID;
    public newInventorySystem inventorySystem;

    public Image[] storeSlots;
    
    
    private int Money;
    private bool notAllowedToBuy;

    private void Start()
    {
        Money = player.GetComponent<playerscript>().Money;
        notAllowedToBuy = false;

        // setting the item display
        storeSlots[0].sprite = itemID.swords[0].item.GetComponent<SpriteRenderer>().sprite;
        storeSlots[1].sprite = itemID.shurkens[0].item.GetComponent<SpriteRenderer>().sprite;
        
        // setting the item name above the slot
        storeSlots[0].transform.GetChild(0).GetComponent<Text>().text = itemID.swords[0].itemName;
        storeSlots[1].transform.GetChild(0).GetComponent<Text>().text = itemID.shurkens[0].itemName;

        // setting the price displayed on the buy button
        storeSlots[0].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = itemID.swords[0].price.ToString();
        storeSlots[1].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = itemID.shurkens[0].price.ToString();

    }

    private void Update()
    {
        //player.GetComponent<playerscript>().Money = Money;

        if (notAllowedToBuy) StartCoroutine(CantBuy());
    }

    public void PayForItem()
    {


    }

    IEnumerator CantBuy()
    {
        cantBuy.SetActive(true);
        yield return new WaitForSeconds(2);
        cantBuy.SetActive(false);
        notAllowedToBuy = false;
    }
}
