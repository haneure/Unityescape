using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    public AudioClip sfx;

    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSfx(AudioClip clip)
    {
        //if(m_MyAudioSource.isPlaying)
        //{
        //    stopSfx();
        //}
        if (sfx == null)
        {
            m_MyAudioSource.clip = clip;
        } else
        {
            m_MyAudioSource.clip = sfx;
        }
        m_MyAudioSource.Play();
    }

    public void stopSfx()
    {
        m_MyAudioSource.Stop();
    }
}
