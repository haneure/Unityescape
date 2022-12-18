using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFov : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    RaycastHit playerHit;

    public Zombie zombie;

    // Start is called before the first frame update
    void Start()
    {
        // playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posTarget = new Vector3(playerRef.transform.position.x, this.transform.position.y, playerRef.transform.position.z);
        if (canSeePlayer)
        {
            Vector3 posPoint = posTarget - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(posPoint);
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2f, this.transform.position.z);
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z), directionToTarget, out playerHit, distanceToTarget, obstructionMask))
                {
                    // Debug.Log(playerHit);
                    canSeePlayer = true;
                    zombie.pursue = true;
                }
                else
                {
                    canSeePlayer = false;
                    zombie.pursue = false;
                }
            }
            else
            {
                canSeePlayer = false;
                zombie.pursue = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
            zombie.pursue = false;
        }
    }
}
