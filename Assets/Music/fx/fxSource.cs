using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxSource : MonoBehaviour
{
    public AudioSource chest;
    public AudioSource key;
    public AudioSource torch;

    public void PlayChest()
    {
        chest.Play ();
    }
    
    public void PlayKey()
    {
        key.Play();
    }

    public void PlayTorch()
    {
        torch.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
