using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pushed() {
        Debug.Log("kya aku didorong");
        m_Rigidbody.AddForce(transform.forward * m_Thrust);
    }
}
