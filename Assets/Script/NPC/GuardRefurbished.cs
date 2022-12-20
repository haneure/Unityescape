using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardRefurbished : MonoBehaviour
{
    private Animator anim;
    [SerializeField] Transform[] point;
    int idxPoint = 0;
    public float speed = 3f;
    private float initialPursueSpeed;
    public float pursueSpeed = 6f;
    bool comeback = false;
    bool reachPoint = false;
    bool left = true;
    bool right = false;

    bool pause = false;

    Vector3 posMusuh;

    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    public GuardRefurbished_Fov fov;
    public bool pursue = false;
    public guard_PlayerDetect playerDetector;

    // Status
    public bool stunned;
    public int stunTime;

    //Hit
    public int hitDamage;
    public float hitDelay;
    float lastAttacked = -9999;
    private int initialStopAfterHitTimer;
    public int stopAfterHitTimer;
    private bool hitOnce = false;
    private int hitCount = 0;
    public bool stopAfterHit = false;
    bool canHit = true;

    public collidergameover gameOverEvent;

    AudioSource m_MyAudioSource;
    //public AudioClip sfx;

    public AudioSource zombieMouth;
    public AudioClip zombieAttackSfx;
    public AudioClip zombieHitSfx;
    public AudioClip[] zombieEncounter;
    public int startEncounter;


    public PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponentInChildren(typeof(Animator)) as Animator;
        m_Rigidbody = this.gameObject.GetComponent<Rigidbody>();
        initialStopAfterHitTimer = stopAfterHitTimer;
        initialPursueSpeed = pursueSpeed;
        fov = this.GetComponentInChildren<GuardRefurbished_Fov>();
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.loop = true;
        zombieMouth = GameObject.Find("ZombieMouth").GetComponent<AudioSource>();
        pauseMenu = GameObject.Find("Menu").GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pause || stunned || stopAfterHit)
        {
            anim.SetBool("Speed", false);
        }
        else
        {
            anim.SetBool("Speed", true);
        }

        if (pauseMenu.GameIsPaused) 
        {
            m_MyAudioSource.Stop();
        }

        if (fov.canSeePlayer == false && startEncounter > 0)
        {
            startEncounter = 0;
            m_MyAudioSource.Stop();
        }

        if (!stunned)
        {
            if(!stopAfterHit)
            {
                if (!pursue)
                {
                    Vector3 posTarget = new Vector3(point[idxPoint].position.x, this.transform.position.y, point[idxPoint].position.z);
                    if (!comeback)
                    {
                        //Waypoint
                        this.transform.position = Vector3.MoveTowards(this.transform.position, posTarget, speed * Time.deltaTime);

                        Vector3 posPoint = posTarget - this.transform.position;
                        this.transform.rotation = Quaternion.LookRotation(posPoint);

                        posMusuh = new Vector3(this.transform.position.x, point[idxPoint].position.y, this.transform.position.z);

                        if (Vector3.Distance(posMusuh, point[idxPoint].position) < 0.1f)
                        {
                            reachPoint = false;
                            idxPoint += 1;
                            if (idxPoint >= point.Length)
                            {
                                idxPoint = point.Length - 1;
                                comeback = true;
                            }
                        }
                    }
                    else
                    {
                        this.transform.position = Vector3.MoveTowards(this.transform.position, posTarget, speed * Time.deltaTime);

                        Vector3 posPoint = posTarget - this.transform.position;
                        this.transform.rotation = Quaternion.LookRotation(posPoint);

                        posMusuh = new Vector3(this.transform.position.x, point[idxPoint].position.y, this.transform.position.z);

                        if (Vector3.Distance(posMusuh, point[idxPoint].position) < 0.1f)
                        {
                            this.transform.rotation = point[idxPoint].transform.rotation;
                            idxPoint -= 1;
                            if (idxPoint <= 0)
                            {
                                idxPoint = 0;
                                comeback = false;
                            }
                        }
                    }
                }
                else
                {
                    //Pursue
                    Vector3 posPlayer = new Vector3(fov.playerRef.transform.position.x, this.transform.position.y, fov.playerRef.transform.position.z);

                    if (fov.canSeePlayer == true)
                    {
                        startEncounter++;
                        if (startEncounter <= 1 && !zombieMouth.isPlaying)
                        {
                            int encounterRng = Random.Range(0, zombieEncounter.Length);
                            zombieMouth.PlayOneShot(zombieEncounter[encounterRng]);
                        }

                        this.transform.position = Vector3.MoveTowards(this.transform.position, posPlayer, pursueSpeed * Time.deltaTime);
                        if (!m_MyAudioSource.isPlaying)
                        {
                            if (!pauseMenu.GameIsPaused)
                            {
                                if (!stunned)
                                {
                                    m_MyAudioSource.Play();
                                }
                            }
                        }
                    }
                }
            } else
            {
                stopAfterHitTimer--;
                if (stopAfterHitTimer <= 0)
                {
                    stopAfterHit = false;
                    stopAfterHitTimer = initialStopAfterHitTimer;
                }
            }

            if(!stopAfterHit)
            {
                if (!stunned)
                {
                   
                }
                
                if (playerDetector.playerTouched == true)
                {
                    if (Time.time > lastAttacked + hitDelay)
                    {
                        Attack();
                        stopAfterHit = true;
                    }
                    
                    m_MyAudioSource.Stop();
                }
            }

        } else
        {
            anim.SetBool("IsDizzy", true);
            stunTime--;
            if (stunTime == 0)
            {
                anim.SetBool("IsDizzy", false);
                stunned = false;
            }
        }
    }

    public void pushed()
    {
        Debug.Log("kya aku didorong");
        m_Rigidbody.AddForce(transform.forward * m_Thrust);
        zombieMouth.PlayOneShot(zombieHitSfx);
    }

    public void Attack()
    {
        zombieMouth.PlayOneShot(zombieAttackSfx);
        stopAfterHit = true;
        playerDetector.player.healthPoint -= hitDamage;
        playerDetector.player.GetAttacked();
        if (playerDetector.player.healthPoint <= 0)
        {
            GameObject.Find("Reticle").SetActive(false);
            playerDetector.player.PlayerDied();
            gameOverEvent.showGameOverUI();
        }
        anim.SetTrigger("HitPlayer");
        lastAttacked = Time.time;
    }

    public void Kick()
    {
        stunned = true;
    }

    // IEnumerator Hit(float delay){
    //     Debug.Log(delay);
    //     anim.SetBool("HitPlayer", true);
    //     playerDetector.player.healthPoint -= 10;
    //     yield return new WaitForSeconds(delay);
    // }

    // private void OnCollisionEnter(Collision other) {
    //     Debug.Log(other.gameObject.name);
    // }

    // void OnDrawGizmosSelected() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(origin, origin + direction * currentHitDistance);
    //     Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    // }
}
