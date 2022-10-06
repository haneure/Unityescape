using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("FirstPersonController").GetComponent<Inventory>();
        // Panel panel = gameObject.GetComponentInChildren();
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        if(inventory.inventory.Count > 0){
            // Debug.Log(inventory.inventory[0].name);
            foreach(var item in inventory.inventory) {
                GameObject inventorySlot = gameObject.transform.GetChild(i).gameObject;

                TextMeshProUGUI text = inventorySlot.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
                text.text = item.name;
                i++;
            }
        } else {
            
        }
        
        Debug.Log(inventory.inventory.Count);
    }

    public void deleteFromInventory(string deleteItem) {
        int i = 0;
        foreach(var item in inventory.inventory) {
            if(item.name == deleteItem){
                Debug.Log("To be deleted: " + item.name);
                GameObject inventorySlot = gameObject.transform.GetChild(i).gameObject;

                TextMeshProUGUI text = inventorySlot.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
                text.text = "";
                inventory.inventory.RemoveAt(i);
                break;
            } else {
                i++;
            }
        }
    }
}
