using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class shopUIRework : MonoBehaviour
{
    public Vector2 offset;

    public itemIDSystem itemIDs;

    public itemData[] itemsToBuy;

    public playerscript player;

    public newInventorySystem inventory;

    void Start()
    {

        foreach (int NonSpecificId in itemIDs.shopableCatagories)
        {
            switch (NonSpecificId)
            {
                case 1:
                    for (int specificID = 0; specificID < itemIDs.swords.Length; specificID++)
                    {
                        if (itemIDs.swords[specificID].buyable)
                        {
                            Array.Resize(ref itemsToBuy, itemsToBuy.Length + 1);
                            itemsToBuy[itemsToBuy.Length - 1] = itemIDs.swords[specificID];
                        }
                    }
                    break;

                case 2:
                    for (int specificID = 0; specificID < itemIDs.shurkens.Length; specificID++)
                    {
                        if (itemIDs.swords[specificID].buyable)
                        {
                            Array.Resize(ref itemsToBuy, itemsToBuy.Length + 1);
                            itemsToBuy[itemsToBuy.Length - 1] = itemIDs.shurkens[specificID];
                        }
                    }
                    break;
            }
        }
        int index = 0;
        foreach (itemData item in itemsToBuy)
        {
            // setup the button location
            GameObject clone = Instantiate(transform.GetChild(0).gameObject, transform); // clone the base object
            clone.SetActive(true);  // set it active
            clone.GetComponent<RectTransform>().offsetMin = transform.GetChild(0).GetComponent<RectTransform>().offsetMin + offset * index;
            clone.GetComponent<RectTransform>().offsetMax = transform.GetChild(0).GetComponent<RectTransform>().offsetMax + offset * index;

            // set the item data
            clone.GetComponent<Image>().sprite = item.item.GetComponent<SpriteRenderer>().sprite;  // set the image
            clone.transform.GetChild(0).GetComponent<Text>().text = item.itemName;  // set the item name
            clone.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "$" + item.price.ToString();  // set the price in the button

            itemData itemBoi = item;  // make seconds variable so that the function is not referancing the variable
            clone.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate() { buyItem(itemBoi); });  // add the listener to the button

            index++;
        }
        
    }

    void buyItem(itemData data)
    {
        if (player.Money - data.price < 0)
        {
            print("player cannot buy this item!");
            // display the player cannot buy text, but for now its a print statement
        }
        else
        {
            print(ArrayUtility.FindIndex(inventory.currentStoredItems, x => x.Equals(data.itemID)));
            player.Money = player.Money - data.price;
            if (inventory.currentStoredItems.Contains(data.itemID) && data.stackable)
            {
                //int index = inventory.currentStoredItems.Length
                print(ArrayUtility.FindIndex(inventory.currentStoredItems, x => x.Equals(data.itemID)));
            }
        }
    }
}
