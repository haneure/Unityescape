using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_walk : MonoBehaviour
{   
    [SerializeField] Transform[] point;
    int idxPoint = 0;
    public float kec = 2f;

 
    void Start()
    {

    }
 
    void Update()
    {
        Vector3 posTarget = new Vector3(point[idxPoint].position.x,this.transform.position.y,point[idxPoint].position.z);
        this.transform.position = Vector3.MoveTowards(this.transform.position,posTarget,kec * Time.deltaTime);

        Vector3 posPutaranTarget = posTarget - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(posPutaranTarget, Vector3.up);

        
        Vector3 posMusuh = new Vector3(this.transform.position.x,
        point[idxPoint].position.y, this.transform.position.z);
        if (Vector3.Distance(posMusuh, point[idxPoint].position)<0.1f) {
            idxPoint += 1;
            if (idxPoint >= point.Length) {
                idxPoint = 0;
            }
        }
    }
}
