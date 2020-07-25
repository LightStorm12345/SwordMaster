using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventorySystem : MonoBehaviour
{
    // -------- important gameObject referances
    public GameObject player; // for giving player items
    public GameObject gameController; // for working with itemIDSytem.cs
    
    
    public GameObject[] inventorySlots; // UI inventory slots
    // placed in lowest to highest order
    public Sprite[] selectionSprites; // Sprites for selected and delected UI sprites
    // 0 = deselected
    // 1 = selected

    // -------- internal code stuff
    
    private int selectedInventorySlot; // current inventory selection

    private string[] itemIDInInventory; // all items in stored inventory (onlt used on script start)
    private GameObject[] itemsInInventory; // actual items stored in inventory (stored as GameObjects for instansiating)
    private int[] itemCounts;
    
    
    
    // giving the player their inventory
    void Start() 
    {

        // this is because unity is weird with array declarations
        // 2 because only 2 of the inventory slots are taken up
        itemsInInventory = new GameObject[2];
        itemIDInInventory = new string[2];
        itemCounts = new int[2];

        // starting invetory slot is always 1
        selectedInventorySlot = 1;

        // this is written this way because there is currently no stored player inventory
        // when the actual stored player inventory becomes a thing, it will be using playerPrefs instead of declarations
        // this is using the predefined itemID system (hexadecimal, see itemIDSystem.cs)
        // nope, not yet ^^^^

        itemIDInInventory[0] = "10";
        itemCounts[0] = 1;

        itemIDInInventory[1] = "20";
        itemCounts[1] = 32;

        // commented because it wont work with the item parser
        //itemIDInInventory[2] = null;
        //itemIDInInventory[3] = null;
        //itemIDInInventory[4] = null;

        // converting itemID to a specific call to itemIDSystem's arrays
        // I.E an item parser

        for (int item = 0; item < itemIDInInventory.Length; item++)
        {    
            int specificItemID;
            
            switch (itemIDInInventory[item].Substring(0, 1))
            {
                case "0":
                    specificItemID = int.Parse(itemIDInInventory[item].Substring(1, 1));
                    itemsInInventory[item] = gameController.GetComponent<itemIDSystem>().generalItems[specificItemID];
                    break;

                case "1":
                    specificItemID = int.Parse(itemIDInInventory[item].Substring(1, 1));
                    itemsInInventory[item] = gameController.GetComponent<itemIDSystem>().swords[specificItemID];
                    break;
                
                case "2":
                    //inventorySlots[item].transform.GetChild(1).gameObject.SetActive(true);

                    specificItemID = int.Parse(itemIDInInventory[item].Substring(1, 1));
                    itemsInInventory[item] = gameController.GetComponent<itemIDSystem>().shurikens[specificItemID];
                    break;
            }

            if (itemCounts[item] > 1)
            {
                inventorySlots[item].transform.GetChild(1).gameObject.SetActive(true);
                inventorySlots[item].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = itemCounts[item].ToString();
            }

        }

        GameObject heldWeapon = Instantiate(itemsInInventory[selectedInventorySlot-1], player.transform);
    }



    // where everything is decided (could not give a better discription)
    void Update()
    {

        // mouse scroll up
        if (Input.mouseScrollDelta.y <= -0.2f)
        {
            if (player.transform.childCount != 0)
            {
                Destroy(player.transform.GetChild(0).gameObject);
            }
            

            // set previous selection to "not selected"
            inventorySlots[selectedInventorySlot-1].GetComponent<Image>().sprite = selectionSprites[0];
            
            // if we are at the end of the inventory loop back around
            if (selectedInventorySlot == 5)
            {
                selectedInventorySlot = 1;
            }

            // else just select the next inventory slot
            else 
            {
                selectedInventorySlot = selectedInventorySlot + 1;
            }

            GameObject heldWeapon = Instantiate(itemsInInventory[selectedInventorySlot-1], player.transform);
        }

        // mouse scroll down
        if (Input.mouseScrollDelta.y >= 0.2f)
        {
            if (player.transform.childCount != 0)
            {
                Destroy(player.transform.GetChild(0).gameObject);
            }

            // set previous selection to "not selected"
            inventorySlots[selectedInventorySlot-1].GetComponent<Image>().sprite = selectionSprites[0];

            // if we are at the end of the inventory loop back around
            if (selectedInventorySlot == 1)
            {
                selectedInventorySlot = 5;
            }

            // else just select the previous inventory slot
            else 
            {
                selectedInventorySlot = selectedInventorySlot - 1;
            }

            GameObject heldWeapon = Instantiate(itemsInInventory[selectedInventorySlot-1], player.transform);
            
        }


        // update sprite to the new selection
        inventorySlots[selectedInventorySlot-1].GetComponent<Image>().sprite = selectionSprites[1];

    }

    // function that AttackScript calls for using item counts (this was painful to write)
    public void SpawnItem()
    {
        // make sure that this is not the last item
        if (itemCounts[selectedInventorySlot-1] != 1)
        {
            // make a new gameObject
            GameObject heldWeapon = Instantiate(itemsInInventory[selectedInventorySlot-1], player.transform);

            // decrement the item count and update the text
            itemCounts[selectedInventorySlot-1] = itemCounts[selectedInventorySlot-1] - 1;
            inventorySlots[selectedInventorySlot-1].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = itemCounts[selectedInventorySlot-1].ToString();
        }

        else
        {
            inventorySlots[selectedInventorySlot-1].transform.GetChild(1).gameObject.SetActive(false);
            inventorySlots[selectedInventorySlot-1].transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
        
    }

}
