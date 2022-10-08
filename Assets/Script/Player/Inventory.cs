using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // public List inventory;
    // public List<GameObject> inventory;
    public List<GameObject> inventory = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void insertToInventory(GameObject item) {
        inventory.Insert(inventory.Count, item);
        Debug.Log(item.name + " added to inventory");
    }

    public void showInventory() {
        foreach(var item in inventory) {
            Debug.Log(item.ToString());
        }
    }
}
