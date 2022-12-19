using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePillar : MonoBehaviour
{
    public Inventory inventory;
    public UI_Inventory ui_inventory;

    public final_door finalDoor;
    bool haveItem;
    // Start is called before the first frame update
    void Start()
    {
        haveItem = false;
        finalDoor = GameObject.Find("FinalDoor").GetComponent<final_door>();
        //inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        //ui_inventory = GameObject.Find("UI_Inventory").GetComponent<UI_Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckInventory(string checkItemName)
    {
        foreach (var item in inventory.inventory)
        {
            if (item.name == checkItemName)
            {
                haveItem = true;
                if (checkItemName == "Faith")
                {
                    finalDoor.faithOnPillar = true;
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                } else if (checkItemName == "Hope")
                {
                    finalDoor.hopeOnPillar = true;
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                } else if (checkItemName == "Charity")
                {
                    finalDoor.charityOnPillar = true;
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            // Debug.Log(inventorySlot);
        }
        if (haveItem == false)
        {
            Debug.Log("don't have item " + checkItemName);
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }


}
