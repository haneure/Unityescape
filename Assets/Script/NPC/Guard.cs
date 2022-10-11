using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    private Animator anim;
    [SerializeField] Transform[] point;
    int idxPoint = 0;
    public float speed = 3f;
    public float pursueSpeed = 6f;
    bool comeback = false;
    bool reachPoint = false;
    bool left = true;
    bool right = false;
    
    public bool pauseWaypoint1;
    public int pauseWaypoint1Timer;
    public bool pauseWaypoint6;
    public int pauseWaypoint6Timer;
    public bool pauseWaypoint7;
    public int pauseWaypoint7Timer;
    public int tempPauseTimer;

    bool pause = false;
    
    Vector3 posMusuh;

    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    public FieldOfView fov;
    public bool pursue = false;
    public guard_PlayerDetect playerDetector;

    // Status
    public bool stunned;
    public int stunTime;

    public collidergameover gameOverEvent;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponentInChildren(typeof(Animator)) as Animator;
        m_Rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(pause || stunned)
        // {
        //     anim.SetBool("Speed", false);
        // }
        // else
        // {
        //     anim.SetBool("Speed", true);
        // }

        if(!stunned) {
            Vector3 posTarget = new Vector3(point[idxPoint].position.x,this.transform.position.y,point[idxPoint].position.z);

            Vector3 posPlayer = new Vector3(fov.playerRef.transform.position.x, this.transform.position.y, fov.playerRef.transform.position.z);

            if(!stunned){
                // if(playerDetector.playerTouched) {
                //     gameOverEvent.showGameOverUI();
                //     playerDetector.playerTouched = false;
                // }
            }
        
            if(comeback == false) {
                if(!pursue) {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, posTarget, speed * Time.deltaTime);
                } else {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, posPlayer, pursueSpeed * Time.deltaTime);
                }

                if(!reachPoint){
                    Vector3 posPoint = posTarget - this.transform.position;
                    this.transform.rotation = Quaternion.LookRotation(posPoint);
                } else {
                    if(idxPoint == 0){
                        // Quaternion target = Quaternion.Euler(point[idxPoint].rotation);
                        // Debug.Log(point[idxPoint].rotation.x + point[idxPoint].rotation.y + point[idxPoint].rotation.z);
                    
                        // Vector3 target = new Vector3(point[idxPoint].rotation.x, point[idxPoint].rotation.y, point[idxPoint].rotation.z);

                        // if(left) {
                        //     Quaternion target = Quaternion.Euler(0, 45, 0);
                        //     this.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 1f);
                        //     if(this.transform.rotation == point[idxPoint].rotation || this.transform.rotation.Equals(point[idxPoint].rotation)){
                        //         left = false;
                        //         right = true;
                        //     }
                        // }

                        // if(right){
                        //     Quaternion target = Quaternion.Euler(0, 135, 0);
                        //     this.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 1f);
                        //     if(this.transform.rotation == point[idxPoint].rotation || this.transform.rotation.Equals(point[idxPoint].rotation)){
                        //         right = false;
                        //         left = true;
                        //     }
                        // }
                        this.transform.rotation = Quaternion.Slerp(transform.rotation, point[idxPoint].rotation,  Time.deltaTime * 1f);

                        // Debug.Log(point[idxPoint].rotation);
                        
                    }
                }


                posMusuh = new Vector3(this.transform.position.x, point[idxPoint].position.y, this.transform.position.z);

                if(pauseWaypoint1) {
                    if(idxPoint == 0 && Vector3.Distance(posMusuh, point[idxPoint].position) < 0.1f) {
                        if(!pause) {
                            tempPauseTimer = pauseWaypoint1Timer;
                        }
                        pause = true;
                        reachPoint = true;
                        left = true;
                    }
                }
                
                if(pauseWaypoint6) {
                    if(idxPoint == 5 && Vector3.Distance(posMusuh, point[idxPoint].position) < 0.1f) {
                        if(!pause) {
                            tempPauseTimer = pauseWaypoint6Timer;
                        }
                        pause = true;
                        reachPoint = true;
                        left = true;
                    }
                }

                if(pauseWaypoint7) {
                    if(idxPoint == 6 && Vector3.Distance(posMusuh, point[idxPoint].position) < 0.1f) {
                        if(!pause) {
                            tempPauseTimer = pauseWaypoint7Timer;
                        }
                        pause = true;
                        reachPoint = true;
                    }
                }

                if(pause) {
                    tempPauseTimer--;
                    if(tempPauseTimer == 0) {
                        pause = false;
                        if (Vector3.Distance(posMusuh, point[idxPoint].position) < 0.1f) {
                        reachPoint = false;
                        idxPoint += 1;
                        if (idxPoint >= point.Length) {
                            idxPoint = point.Length - 1;
                            comeback = true;
                        }
                    }
                    }
                } else {
                    if (Vector3.Distance(posMusuh, point[idxPoint].position) < 0.1f) {
                        reachPoint = false;
                        idxPoint += 1;
                        if (idxPoint >= point.Length) {
                            idxPoint = point.Length - 1;
                            comeback = true;
                        }
                    }
                }

            } else {
                this.transform.position = Vector3.MoveTowards(this.transform.position, posTarget, speed * Time.deltaTime);

                Vector3 posPoint = posTarget - this.transform.position;
                this.transform.rotation = Quaternion.LookRotation(posPoint);
                

                posMusuh = new Vector3(this.transform.position.x, point[idxPoint].position.y, this.transform.position.z);
                if (Vector3.Distance(posMusuh, point[idxPoint].position) < 0.1f) {
                    this.transform.rotation = point[idxPoint].transform.rotation;
                    idxPoint -= 1;
                    if (idxPoint <= 0) {
                        idxPoint = 0;
                        comeback = false;
                    }
                }
            }
        } else {
            stunTime--;
            Quaternion target = Quaternion.Euler(0, 360, 0);
            this.transform.rotation =  Quaternion.RotateTowards(this.transform.rotation, target, 2f * Time.deltaTime);
            if(stunTime == 0) {
                stunned = false;
            }
        }

    }

    public void pushed() {
        Debug.Log("kya aku didorong");
        m_Rigidbody.AddForce(transform.forward * m_Thrust);
    }

    // private void OnCollisionEnter(Collision other) {
    //     Debug.Log(other.gameObject.name);
    // }

    // void OnDrawGizmosSelected() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(origin, origin + direction * currentHitDistance);
    //     Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    // }
}
