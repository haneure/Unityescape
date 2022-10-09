using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class t_collider : MonoBehaviour
{
    // h_ = Hint Events

    public GameObject hintToShow;
    [SerializeField] TextMeshProUGUI hint_ctrl;
    public bool h_showCTRL = false;
    bool showCTRLEvent = true;
    int onetime;

    bool tutorial = false;

    public GameObject showRocksHints;
    // Start is called before the first frame update
    void Start()
    {
        onetime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(h_showCTRL == true && onetime == 1) {
            if(Input.GetKeyDown("left ctrl")) {
                // hintToShow.gameObject.SetActive(false);
                hint_ctrl.text = "Hold right click to Aim";
            }
            if(Input.GetKeyUp(KeyCode.Mouse1) ) {
                hint_ctrl.text = "The guard is always patrolling, but stay alert! He could come back sooner or later! Look at your surroundings, analyze, try to find something usefull and make your way out of here!";
                showRocksHints.gameObject.SetActive(true);
                h_showCTRL = false;
            }
        }


    }

    private void OnTriggerEnter(Collider other) {
        // Show CTRL Event
        if(other.gameObject.name  == "Player" && showCTRLEvent && onetime < 1) {
            hintToShow.gameObject.SetActive(true);
            h_showCTRL = true;
            onetime += 1;
        }
    }
}
