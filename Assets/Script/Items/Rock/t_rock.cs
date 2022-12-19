using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_rock : MonoBehaviour
{
    Guard guard;
    Zombie zombie;

    public AudioSource rockAudio;
    private float openDelay = 0;

    public AudioClip rockThrow;
    private float volume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "zombie")
        {
            zombie = GameObject.Find(other.gameObject.name).GetComponent<Zombie>();
            zombie.stunTime = 2000;
            zombie.stunned = true;
            zombie.zombieMouth.PlayOneShot(zombie.zombieHitSfx);
        }

        if(other.gameObject.tag == "guard" || other.transform.root.CompareTag("guard") || other.gameObject.tag == "ground") {
            rockAudio = this.gameObject.AddComponent<AudioSource>();
            rockAudio.PlayOneShot(rockThrow, volume);
            Debug.Log(other.gameObject.tag);
            if(other.gameObject.tag == "guard"){
                guard = GameObject.Find(other.gameObject.name).GetComponent<Guard>();
                guard.stunTime = 150;
                guard.stunned = true;
            } else if (other.transform.root.CompareTag("guard")) {
                Debug.Log(other.transform.parent.name);
                guard = GameObject.Find(other.transform.parent.name).GetComponent<Guard>();
                guard.stunTime = 150;
                guard.stunned = true;
            }
        }
    }
}
