using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newInventorySystem : MonoBehaviour
{
    public string[] currentStoredItems;

    public int[] itemCounts;

    [HideInInspector]
    public GameObject[] usableStoredInventory;

    public itemIDSystem itemIDs;
    public GameObject[] UIInventorySlots;

    private void Start()
    {
        currentStoredItems = new string[5];
        itemCounts = new int[5];
        usableStoredInventory = new GameObject[5];
        // if an item count is 0, it essentially means null

        currentStoredItems[0] = "20";
        itemCounts[0] = 1;

        currentStoredItems[1] = "30";
        itemCounts[1] = 99;

        currentStoredItems[2] = null;
        itemCounts[2] = 0;

        currentStoredItems[3] = null;
        itemCounts[3] = 0;

        currentStoredItems[4] = null;
        itemCounts[4] = 0;
    }

    public void GenerateInventory()
    {
        /*currentStoredItems = new string[5];
        itemCounts = new int[5];
        usableStoredInventory = new GameObject[5];
        // if an item count is 0, it essentially means null

        currentStoredItems[0] = "20";
        itemCounts[0] = 1;

        currentStoredItems[1] = "30";
        itemCounts[1] = 99;

        currentStoredItems[2] = null;
        itemCounts[2] = 0;

        currentStoredItems[3] = null;
        itemCounts[3] = 0;

        currentStoredItems[4] = null;
        itemCounts[4] = 0;*/

        // looping through each element for inventory slot generation
        for (int item = 0; item < currentStoredItems.Length; item++)
        {
            string selectedItem = currentStoredItems[item];

            // check if the slot contains nothing
            if (selectedItem == null)
            {
                UIInventorySlots[item].transform.GetChild(0).GetComponent<Image>().enabled = false;
                usableStoredInventory[item] = null;
                continue;
            }

            // if the item count is more than 1, set the item counter to enabled, then set the item count text
            // should be updated to use "stackable" setting in itemData
            if (itemCounts[item] > 1)
            {
                UIInventorySlots[item].transform.GetChild(1).gameObject.SetActive(true);
                UIInventorySlots[item].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = itemCounts[item].ToString();
            }

            // set the inventory space, and also the appropriate image for the slot
            string generalizedItemID = selectedItem.Substring(0, 1);
            switch (generalizedItemID)
            {
                case "1":
                    usableStoredInventory[item] = itemIDs.generalItems[int.Parse(selectedItem.Substring(1, 1))].item;
                    UIInventorySlots[item].transform.GetChild(0).GetComponent<Image>().sprite = itemIDs.generalItems[int.Parse(selectedItem.Substring(1, 1))].item.GetComponent<SpriteRenderer>().sprite;
                    break;

                case "2":
                    usableStoredInventory[item] = itemIDs.swords[int.Parse(selectedItem.Substring(1, 1))].item;
                    UIInventorySlots[item].transform.GetChild(0).GetComponent<Image>().sprite = itemIDs.swords[int.Parse(selectedItem.Substring(1, 1))].item.GetComponent<SpriteRenderer>().sprite;
                    break;

                case "3":
                    usableStoredInventory[item] = itemIDs.shurkens[int.Parse(selectedItem.Substring(1, 1))].item;
                    UIInventorySlots[item].transform.GetChild(0).GetComponent<Image>().sprite = itemIDs.shurkens[int.Parse(selectedItem.Substring(1, 1))].item.GetComponent<SpriteRenderer>().sprite;
                    break;
            }
        }

    }

}
