using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeScript : MonoBehaviour
{
    public bool fadeOutAndFadeIn = false;
    public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            
            Debug.Log(audioSource.volume);
            Debug.Log(audioSource.clip.name);
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public IEnumerator FadeIn(AudioSource audioSource, float FadeTime, float volume)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < volume)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = volume;
    }

    public IEnumerator FadeOutAndFadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        if (!fadeOutAndFadeIn)
        {
            while (audioSource.volume > 0)
            {

                Debug.Log(audioSource.volume);
                Debug.Log(audioSource.clip.name);
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            audioSource.Stop();
            audioSource.volume = startVolume;
            fadeOutAndFadeIn = true;
        } else
        {
            audioSource.volume = 0;

            while (audioSource.volume < startVolume)
            {

                audioSource.volume += startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }
            //audioSource.Play();
            audioSource.volume = startVolume;
        }

    }
}
