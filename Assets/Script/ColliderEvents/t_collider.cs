using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_collider : MonoBehaviour
{
    // h_ = Hint Events

    public GameObject hintToShow;
    public bool h_showCTRL = false;
    bool showCTRLEvent = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(h_showCTRL == true) {
            if(Input.GetKeyDown("left ctrl")) {
                hintToShow.gameObject.SetActive(false);
                h_showCTRL = false;
                showCTRLEvent = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        // Show CTRL Event
        if(other.gameObject.name  == "Player" && showCTRLEvent) {
            hintToShow.gameObject.SetActive(true);
            h_showCTRL = true;
        }
    }
}
