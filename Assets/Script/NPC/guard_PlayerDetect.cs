using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guard_PlayerDetect : MonoBehaviour
{
    public bool playerTouched = false;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        // Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Player"){
            player = other.gameObject.GetComponent<Player>();
            playerTouched = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.name == "Player"){
            player = other.gameObject.GetComponent<Player>();
            playerTouched = false;
        }
    }
}
