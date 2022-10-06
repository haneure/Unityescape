using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_chest : MonoBehaviour
{
    private Animator anim;
    public bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void triggerChest() {
        if(!open) {
            anim.SetTrigger("Activate");
        } else {
            anim.ResetTrigger("Activate");
        }
    }
}
