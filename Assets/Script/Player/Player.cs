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

    public GameObject throwRocksHint, body, face;
    bool tutorial = true;
   
    [SerializeField] float fallThresholdVelocity;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpHeight = 5f;

    public bool grounded;

    Transform player;
    private Animator animator;
    public Rigidbody rigid;
    public collidergameover gameOverEvent;

    public bool dialogueStatus = false;

    private AudioSource playerSoundSource;
    public AudioClip getHitSound;
    public AudioClip diedSound;
    public AudioClip gameOverMusic;

    public CapsuleCollider capsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerSoundSource = GameObject.Find("mouth").GetComponent<AudioSource>();
        gameOverEvent = GetComponent<collidergameover>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        player = this.gameObject.transform.GetChild(0);
        capsuleCollider = GetComponent<CapsuleCollider>();
        if(throwRocksHint != null) {
            tutorial = false;
        }
        if(Application.isMobilePlatform)
        {
            body.SetActive(false);
            face.SetActive(false);
        }
        else
        {
            body.SetActive(true);
            face.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        bool previousGrounded = grounded;
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer, QueryTriggerInteraction.Ignore);
        //Debug.Log(rigid.velocity.y);

        if (!previousGrounded && grounded) {
             Debug.Log("Do damage: " + (rigid.velocity.y < -fallThresholdVelocity));


            if (rigid.velocity.y < -fallThresholdVelocity){
                float damage = Mathf.Abs(rigid.velocity.y + fallThresholdVelocity) + 7;
                GetAttacked();
                //Debug.Log("fall damage: " + damage);
                if(damage > 3) {
                    healthPoint -= damage + 7;
                    if (healthPoint <= 0)
                    {
                        healthPoint = 0;
                        gameOver();
                    }
                }
                Debug.Log("Damage dealt: " + damage);
            }

            animator.SetBool("Jump", false);
        }

        if(grounded)
        {
            if (Input.GetButtonDown("Crouch"))
            {
                capsuleCollider.height = capsuleCollider.height / 2;
            }
        }

        healthUI.text = "HP: " + Mathf.RoundToInt(healthPoint);

        if(Application.isMobilePlatform)
        {
            //Throw rock
            if (Input.GetButton("Aim")) {
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

                if (Input.GetButtonUp("Fire1") && Time.time > nextFire) {
                    if (haveRock) {
                        if (tutorial == false) {
                            throwRocksHint.gameObject.SetActive(false);
                            tutorial = true;
                        }

                        nextFire = Time.time + fireRate;
                        GameObject projectile = Instantiate(bullet) as GameObject;
                        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + adjustY, transform.position.z);

                        projectile.transform.position = spawnPosition + Camera.main.transform.forward * 2;
                        Rigidbody rb = projectile.GetComponent<Rigidbody>();
                        rb.velocity = Camera.main.transform.forward * 40;

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
        else
        {
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
                    if (haveRock && dialogueStatus == false) {
                        if(tutorial == false){
                            throwRocksHint.gameObject.SetActive(false);
                            tutorial = true;
                        }

                        nextFire = Time.time + fireRate;
                        GameObject projectile = Instantiate(bullet) as GameObject;
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
    }

    public void SetDialogueStatus(bool status)
    {
        dialogueStatus = status;
    }

    private void Jump() {
        if(grounded) rigid.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
    }

    public void GetAttacked()
    {
        playerSoundSource.PlayOneShot(getHitSound, 0.8f);
    }

    public void PlayerDied()
    {
        playerSoundSource.PlayOneShot(diedSound, 0.7f);
    }

    public void GivePlayerHeal(AudioClip healSfx)
    {
        healthPoint = 100;
        playerSoundSource.PlayOneShot(healSfx, 0.7f);
    }

    public void gameOver()
    {
        PlayerDied();
        AudioSource backgroundMusic = GameObject.Find("backgroundmusic").GetComponent<AudioSource>();
        backgroundMusic.Stop();
        backgroundMusic.clip = gameOverMusic;
        backgroundMusic.Play();
        gameOverEvent.showGameOverUI();
    }


}