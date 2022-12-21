using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
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

    public ZombieFov fov;
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
        fov = this.GetComponentInChildren<ZombieFov>();
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.loop = true;
        zombieMouth = GameObject.Find("ZombieMouth").GetComponent<AudioSource>();
        pauseMenu = GameObject.Find("Menu").GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.GameIsPaused) 
        {
            m_MyAudioSource.Stop();
        }

        if (!stunned)
        {
            Vector3 posPlayer = new Vector3(fov.playerRef.transform.position.x, this.transform.position.y, fov.playerRef.transform.position.z);

            if (fov.canSeePlayer == true)
            {
                startEncounter++;
                if(startEncounter <= 1 && !zombieMouth.isPlaying)
                {
                    int encounterRng = Random.Range(0, 4);
                    zombieMouth.PlayOneShot(zombieEncounter[encounterRng]);
                }

                this.transform.position = Vector3.MoveTowards(this.transform.position, posPlayer, pursueSpeed * Time.deltaTime);
                if (!m_MyAudioSource.isPlaying)
                {
                    if(!pauseMenu.GameIsPaused)
                    {
                        if(!stunned)
                        {
                            m_MyAudioSource.Play();
                        }
                    }
                }
            } else
            {
                startEncounter = 0;
                anim.SetBool("Crawl", false);
                m_MyAudioSource.Stop();
            }

            if(stopAfterHit)
            {
                m_MyAudioSource.Stop();
                anim.SetBool("Crawl", false);
                stopAfterHitTimer--;
                pursueSpeed = 0;
                if (stopAfterHitTimer <= 0)
                {
                    stopAfterHit = false;
                    stopAfterHitTimer = initialStopAfterHitTimer;
                    pursueSpeed = initialPursueSpeed;
                }
            }

            if(!stopAfterHit)
            {
                if (!stunned)
                {
                    anim.SetBool("Crawl", true);
                }
                
                if (playerDetector.playerTouched == true)
                {
                    if (Time.time > lastAttacked + hitDelay)
                    {
                        Attack();
                        stopAfterHit = true;
                    }
                    anim.SetBool("Crawl", false);
                    m_MyAudioSource.Stop();
                }
            }

        } else
        {
            stunTime--;
            if (stunTime == 0)
            {
                anim.SetBool("Crawl", true);
                stunned = false;
            }
        }
    }

    public void pushed()
    {
        Debug.Log("kya aku didorong");
        stunned = true;
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
            playerDetector.player.healthPoint = 0;
            GameObject.Find("Reticle").SetActive(false);
            playerDetector.player.gameOver();
            //gameOverEvent.showGameOverUI();
        }
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
