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
    }

    // Update is called once per frame
    void Update()
    {
        if (!stunned)
        {
            Vector3 posPlayer = new Vector3(fov.playerRef.transform.position.x, this.transform.position.y, fov.playerRef.transform.position.z);
            //Debug.Log(posPlayer);
            //Debug.Log(fov.canSeePlayer);

            if (fov.canSeePlayer == true)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, posPlayer, pursueSpeed * Time.deltaTime);
                if (!m_MyAudioSource.isPlaying)
                {
                    m_MyAudioSource.Play();
                }
            } else
            {
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
                anim.SetBool("Crawl", true);
                if (playerDetector.playerTouched == true)
                {
                    if (Time.time > lastAttacked + hitDelay)
                    {
                        Hit();
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
                anim.SetBool("Crawl", false);
                stunned = false;
            }
        }
        //if (!stunned)
        //{
        //    Vector3 posPlayer = new Vector3(fov.playerRef.transform.position.x, this.transform.position.y, fov.playerRef.transform.position.z);

        //    if (stopAfterHit)
        //    {
        //        stopAfterHitTimer--;
        //        if (stopAfterHitTimer <= 0)
        //        {
        //            stopAfterHit = false;
        //            stopAfterHitTimer = initialStopAfterHitTimer;
        //        }
        //    }

        //    if (playerDetector.playerTouched)
        //    {
        //        if (Time.time > lastAttacked + hitDelay)
        //        {
        //            Hit();
        //        }
        //    }

        //    if (comeback == false)
        //    {
        //        if (!stopAfterHit)
        //        {
        //            if (!pursue)
        //            {

        //            }
        //            else
        //            {
        //                this.transform.position = Vector3.MoveTowards(this.transform.position, posPlayer, pursueSpeed * Time.deltaTime);
        //            }
        //        }


        //        if (!reachPoint)
        //        {
        //            if (!pursue)
        //            {

        //            }
        //            else
        //            {
        //                Vector3 posPoint = posPlayer - this.transform.position;
        //                this.transform.rotation = Quaternion.LookRotation(posPoint);
        //            }
        //        }
        //        else
        //        {
        //            if (idxPoint == 0)
        //            {
        //                this.transform.rotation = Quaternion.Slerp(transform.rotation, point[idxPoint].rotation, Time.deltaTime * 1f);
        //            }
        //        }


        //        posMusuh = new Vector3(this.transform.position.x, point[idxPoint].position.y, this.transform.position.z);

        //    }
        //    else
        //    {
        //        // this.transform.position = Vector3.MoveTowards(this.transform.position, posTarget, speed * Time.deltaTime);

        //        if (!stopAfterHit)
        //        {
        //            if (!pursue)
        //            {
        //                anim.SetBool("Crawl", false);
        //            }
        //            else
        //            {
        //                anim.SetBool("Crawl", true);
        //                this.transform.position = Vector3.MoveTowards(this.transform.position, posPlayer, pursueSpeed * Time.deltaTime);
        //            }
        //        }

        //        if (!pursue)
        //        {
        //        }
        //        else
        //        {
        //            Vector3 posPoint = posPlayer - this.transform.position;
        //            this.transform.rotation = Quaternion.LookRotation(posPoint);
        //        }

        //        posMusuh = new Vector3(this.transform.position.x, point[idxPoint].position.y, this.transform.position.z);
        //        if (Vector3.Distance(posMusuh, point[idxPoint].position) < 0.1f)
        //        {
        //            this.transform.rotation = point[idxPoint].transform.rotation;
        //            idxPoint -= 1;
        //            if (idxPoint <= 0)
        //            {
        //                idxPoint = 0;
        //                comeback = false;
        //            }
        //        }
        //    }
        //}
        //else
        //{
        //    stunTime--;
        //    Quaternion target = Quaternion.Euler(0, 360, 0);
        //    this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, target, 2f * Time.deltaTime);
        //    if (stunTime == 0)
        //    {
        //        stunned = false;
        //    }
        //}

    }

    public void pushed()
    {
        Debug.Log("kya aku didorong");
        m_Rigidbody.AddForce(transform.forward * m_Thrust);
    }

    public void Hit()
    {
        stopAfterHit = true;
        playerDetector.player.healthPoint -= hitDamage;
        if (playerDetector.player.healthPoint <= 0)
        {
            gameOverEvent.showGameOverUI();
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
