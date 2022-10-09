using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dt_collider : MonoBehaviour
{
    int onetime;

    public bool dt_showHint = false;
    public GameObject hintToShow;
    
    public bool dt_hideHint = false;
    public GameObject hintToHide;
    
    // Start is called before the first frame update
    void Start()
    {
        onetime = 0;
    }

    // Update is called once per frame
    void Update()
    { 

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name  == "Player" && dt_hideHint && onetime < 1) {
            hintToHide.gameObject.SetActive(false);
            dt_hideHint = false;
            if(dt_showHint) {
                hintToShow.gameObject.SetActive(true);
            }
        }
    }
}
