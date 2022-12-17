using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class t_jailbar3 : MonoBehaviour
{
    public Inventory inventory;
    public bool haveKey = false;
    public GameObject keyhole;
    GameObject jailbar;
    public UI_Inventory inventori;

    public AudioSource jailOpenAudio = null;
    private float openDelay = 0;
    // Start is called before the first frame update
    void Start()
    {
        // inventory = GameObject.Find("Player").GetComponent<Inventory>();
        Debug.Log(inventori.inventory);
        jailbar = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openJailbar() {
        foreach(var item in inventory.inventory) {
            if(item.name == "rust_key3"){
                haveKey = true;
            } else {
                Debug.Log("rust_key is not in your inventory");
            }
            // Debug.Log(inventorySlot);
        }

        if(haveKey) {
            keyhole.SetActive(false);
            jailbar.SetActive(false);
            inventori.deleteFromInventory("rust_key3");
            jailOpenAudio.PlayDelayed(openDelay);
            // nextScene();
        } else {
            Debug.Log("Kamu tidak punya kunci");
        }
    }

    // public void nextScene() {
    //     SceneManager.LoadScene("2.OutsideJail");
    // }
}
