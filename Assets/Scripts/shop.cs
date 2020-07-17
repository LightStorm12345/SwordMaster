using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject interactionUI;
    public GameObject shopUI;


    void Update()
    {
        if (shopUI.activeSelf == false && interactionUI.activeSelf == true && Input.GetKeyDown(KeyCode.E))
        {
            shopUI.SetActive(true);
            Time.timeScale = 0;
            interactionUI.SetActive(false);
        }
        
        else if (shopUI.activeSelf == true && Input.GetKeyDown(KeyCode.E))
        {
            shopUI.SetActive(false);
            Time.timeScale = 1;
            interactionUI.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactionUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactionUI.SetActive(false);
        }
    }
}
