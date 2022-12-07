using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] public float healthPoint;
    public TextMeshProUGUI healthUI;

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
   
    [SerializeField] float fallThresholdVelocity;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpHeight = 5f;

    public bool grounded;

    Transform player;
    private Animator animator;
    private Rigidbody rigid;
    public collidergameover gameOverEvent;
    // Start is called before the first frame update
    void Start()
    {
        gameOverEvent = GetComponent<collidergameover>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        player = this.gameObject.transform.GetChild(0);
        if(throwRocksHint != null) {
            tutorial = false;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        bool previousGrounded = grounded;
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer, QueryTriggerInteraction.Ignore);
        
        if(!previousGrounded && grounded) {
            // Debug.Log("Do damage: " + (rigid.velocity.y < -fallThresholdVelocity));

            if(rigid.velocity.y < -fallThresholdVelocity){
                float damage = Mathf.Abs(rigid.velocity.y + fallThresholdVelocity) + 7;
                if(damage > 3) {
                    healthPoint -= damage + 7;
                }
                Debug.Log("Damage dealt: " + damage);
            }

            animator.SetBool("Jump", false);
        }

        healthUI.text = "HP: " + Mathf.RoundToInt(healthPoint);

        //Throw rock
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
        
        //Jump
        //if (Input.GetButton("Jump")) {
        //    Jump();
        //}
    }

    private void Jump() {
        if(grounded) rigid.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
    }
}
