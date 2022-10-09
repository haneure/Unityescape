using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float bulletVelocity = 1f;
    public float fireRate = 1;
    private float nextFire = 0.0F;
    [SerializeField] GameObject bullet;
    public float adjustY;

    public Inventory inventory;
    public UI_Inventory inventori;

    public bool haveRock = false;

    public GameObject throwRocksHint;
    bool tutorial = true;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.transform.GetChild(0);
        if(throwRocksHint != null) {
            tutorial = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) {
            if(!haveRock){
                if(inventory.inventory.Count > 0){
                    foreach(var item in inventory.inventory) {
                        if(item.name == "Rock"){
                            haveRock = true;
                        }
                        // Debug.Log(inventorySlot);
                    }
                }
            }

            if (Input.GetKeyUp(KeyCode.Mouse0) && Time.time > nextFire) {
                if(haveRock) {
                    if(tutorial == false){
                        throwRocksHint.gameObject.SetActive(false);
                        tutorial = true;
                    }
                    
                    nextFire = Time.time + fireRate;
                    GameObject projectile = Instantiate(bullet)as GameObject;
                    Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + adjustY, transform.position.z);

                    projectile.transform.position = spawnPosition + Camera.main.transform.forward * 2;
                    Rigidbody rb = projectile.GetComponent<Rigidbody>();
                    rb.velocity= Camera.main.transform.forward * 40;
                    inventori.deleteFromInventory("Rock");
                    haveRock = false;
                } else {
                    Debug.Log("Rock is not in your inventory");
                }
            }
        } 
        

        // player.transform.position = 
        // this.transform.position = new Vector3(this.transform.position.x + player.transform.position.x, this.transform.position.y + player.transform.position.y, this.transform.position.z + player.transform.position.z);
    }
}
