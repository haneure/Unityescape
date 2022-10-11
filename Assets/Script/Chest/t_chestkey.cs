using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class t_chestkey : MonoBehaviour
{
    private Animator anim;
    public bool open;

    public Inventory inventory;
    public bool haveKey = false;
    public GameObject keyhole;
    public UI_Inventory inventori;

    public AudioSource chestOpenAudio = null;
    private float openDelay = 0;
    // Start is called before the first frame update
    void Start()
    {
        // keyhole = this.gameObject;
        Debug.Log(inventori.inventory);
        
        anim = this.GetComponent<Animator>();
        // if(SceneManager.GetActiveScene().name == "2.OutsideJail"){
        //     triggerChest();
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openChest()
    {
        foreach(var item in inventory.inventory) {
            if(item.name == "rust_keychest"){
                haveKey = true;
            } else {
                Debug.Log("rust_key is not in your inventory");
            }
            // Debug.Log(inventorySlot);
        }

        if(haveKey && !open) {
            keyhole.SetActive(false);
            inventori.deleteFromInventory("rust_keychest");
            anim.SetTrigger("Activate");
            inventori.deleteFromInventory("rust_keychest");
            open = true;
            chestOpenAudio.PlayDelayed(openDelay);
        } else {
            Debug.Log("Kamu tidak punya kunci");
            anim.ResetTrigger("Activate");
            open = false;
        }
    }

    // public void triggerChest() {
    //     if(!open) {
    //         anim.SetTrigger("Activate");
    //         inventori.deleteFromInventory("rust_keychest");
    //         open = true;
    //     } else {
    //         anim.ResetTrigger("Activate");
    //         open = false;
    //     }
    // }
}
