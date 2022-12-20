using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // public List inventory;
    // public List<GameObject> inventory;
    public List<GameObject> inventory = new List<GameObject>();
    public UI_Inventory inventori;
    // Start is called before the first frame update
    void Start()
    {
        inventori = GameObject.Find("UI_Inventory").GetComponent<UI_Inventory>();
        inventory = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void insertToInventory(GameObject item) {
        Debug.Log(inventory.Count);
        if(inventory.Count < 5)
        {
            inventory.Insert(inventory.Count, item);
        }
        //inventory.Insert(inventory.Count, item);
        Debug.Log(item.name + " added to inventory");
    }

    public void DeleteFromInventory(string itemName)
    {
        foreach (var item in inventory)
        {
            if (item.name == "Higanbana")
            {
                inventori.deleteFromInventory("Higanbana");
            }
            else
            {
                Debug.Log("Higanbana is not in your inventory");
            }
        }
    }

    public void showInventory() {
        foreach(var item in inventory) {
            Debug.Log(item.ToString());
        }
    }
}
