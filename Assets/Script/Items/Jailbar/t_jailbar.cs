using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class t_jailbar : MonoBehaviour
{
    public Inventory inventory;
    public bool haveKey = false;
    GameObject keyhole;
    public UI_Inventory inventori;
    public colliderwin showWinUI;

    public AudioSource jailOpenAudio = null;
    private float openDelay = 0;
    // Start is called before the first frame update
    void Start()
    {
        // inventory = GameObject.Find("Player").GetComponent<Inventory>();
        keyhole = this.gameObject;
        Debug.Log(inventori.inventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openJailbar() {
        foreach(var item in inventory.inventory) {
            if(item.name == "rust_key"){
                haveKey = true;
            } else {
                Debug.Log("rust_key is not in your inventory");
            }
            // Debug.Log(inventorySlot);
        }

        if(haveKey) {
            keyhole.SetActive(false);
            inventori.deleteFromInventory("rust_key");
            jailOpenAudio.PlayDelayed(openDelay);
            // showWinUI.showWinUI();
            SceneManager.LoadScene(showWinUI.nextGame);
        } else {
            Debug.Log("Kamu tidak punya kunci");
        }
    }
}
