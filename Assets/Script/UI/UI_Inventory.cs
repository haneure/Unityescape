using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    public Inventory inventory;
    public bool updateInventory = false;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        Debug.Log(inventory);
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

                TextMeshProUGUI text = inventorySlot.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                text.text = item.name;
                i++;
            }
        } else {
            
        }

        if(updateInventory) {
            for(int z = 0; z < 5; z++) {
                GameObject inventorySlot = gameObject.transform.GetChild(z).gameObject;

                TextMeshProUGUI text = inventorySlot.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                text.text = "";
            }
            updateInventory = false;
        }
        
        // Debug.Log(inventory.inventory.Count);
    }

    public void deleteFromInventory(string deleteItem) {
        int i = 0;
        foreach(var item in inventory.inventory) {
            if(item.name == deleteItem){
                Debug.Log("To be deleted: " + item.name);
                GameObject inventorySlot = gameObject.transform.GetChild(i).gameObject;

                TextMeshProUGUI text = inventorySlot.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                text.text = "";
                inventory.inventory.RemoveAt(i);

                List<GameObject> newInventory = new List<GameObject>();
                int j = 0;
                foreach(var items in inventory.inventory) {
                    newInventory.Insert(j, items);
                    j++;
                    Debug.Log(items.name);
                }

                inventory.inventory = newInventory;
                updateInventory = true;
                
                break;
            } else {
                i++;
            }
        }
    }
}
