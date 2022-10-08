using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class t_chest : MonoBehaviour
{
    private Animator anim;
    public bool open;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        if(SceneManager.GetActiveScene().name == "2.OutsideJail"){
            triggerChest();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void triggerChest() {
        if(!open) {
            anim.SetTrigger("Activate");
            open = true;
        } else {
            anim.ResetTrigger("Activate");
            open = false;
        }
    }
}
