using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public PauseMenu pauseMenu;

    void Start()
    {
        pauseMenu = GameObject.Find("Menu").GetComponent<PauseMenu>();
    }
    void Update()
    {
    }

    public void SetVolume (float volume)
    {
        // Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
}
