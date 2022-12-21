using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstep : MonoBehaviour
{
    public AudioSource footstepSound;
    public Player player;

    // // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Player>();
        footstepSound = GetComponent<AudioSource>();
}

    // Update is called once per frame
    void Update()
    {
        if((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))
        {
            if(player.grounded)
            {
                footstepSound.enabled = true;
            } else
            {
                footstepSound.enabled = false;
            }
        }
        else
        {
            footstepSound.enabled = false;
        }
    }
}
