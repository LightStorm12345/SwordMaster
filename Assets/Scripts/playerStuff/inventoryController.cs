using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryController : MonoBehaviour
{
    public newInventorySystem inventorySystem;
    public Transform itemHolder;
    public Sprite[] uiSprites;
    // 0 = unselected
    // 1 = selcted
    private GameObject[] UISlots;
    private GameObject[] storedItems;

    private int selectedSlot;

    void Start()
    {
        // generate the player inventory
        inventorySystem.GenerateInventory();

        storedItems = new GameObject[5];
        UISlots = new GameObject[5];

        storedItems = inventorySystem.usableStoredInventory;  // get the parsed stored items
        UISlots = inventorySystem.UIInventorySlots;  // get the ui slots, reduces the need to assign is this script

        // select the default slot
        selectedSlot = 1;
        if (storedItems[selectedSlot - 1] != null) Instantiate(storedItems[selectedSlot - 1], itemHolder);

    }

   void Update()
    {
        if (Input.mouseScrollDelta.y <= -0.2f)
        {
            if (itemHolder.childCount != 0)
            {
            Destroy(itemHolder.GetChild(0).gameObject);
            }

            UISlots[selectedSlot - 1].GetComponent<Image>().sprite = uiSprites[0];
            
            // loop back
            if (selectedSlot == 5) selectedSlot = 1;
            else selectedSlot = selectedSlot + 1;

            UISlots[selectedSlot - 1].GetComponent<Image>().sprite = uiSprites[1];
            
            if (storedItems[selectedSlot -1] != null) Instantiate(storedItems[selectedSlot - 1], itemHolder);
        }
        if (Input.mouseScrollDelta.y >= 0.2f)
        {
            if (itemHolder.childCount != 0)
            {
            Destroy(itemHolder.GetChild(0).gameObject);
            }

            UISlots[selectedSlot - 1].GetComponent<Image>().sprite = uiSprites[0];

            // loop back
            if (selectedSlot == 1) selectedSlot = 5;
            else selectedSlot = selectedSlot - 1;

            UISlots[selectedSlot - 1].GetComponent<Image>().sprite = uiSprites[1];
            if (storedItems[selectedSlot - 1] != null) Instantiate(storedItems[selectedSlot - 1], itemHolder);
        }
    }

    public void SpawnItem()
    {
        // make sure it is not the last item
        if (inventorySystem.itemCounts[selectedSlot - 1] != 1)
        {
            Instantiate(storedItems[selectedSlot - 1], itemHolder);
            inventorySystem.itemCounts[selectedSlot - 1] = inventorySystem.itemCounts[selectedSlot - 1] - 1;
            UISlots[selectedSlot - 1].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = inventorySystem.itemCounts[selectedSlot - 1].ToString();
        }

        // player inventory is empty
        else
        {
            UISlots[selectedSlot - 1].transform.GetChild(1).gameObject.SetActive(false);
            UISlots[selectedSlot - 1].transform.GetChild(0).GetComponent<Image>().sprite = null;
            UISlots[selectedSlot - 1].transform.GetChild(0).GetComponent<Image>().enabled = false;
            storedItems[selectedSlot - 1] = null;
        }
    }
}
