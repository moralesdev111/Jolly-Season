using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] musicSound, sfxSound;
    public AudioSource  musicSource, sfxSource;

    private void Start()
    {      
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSound, x=> x.name == name);
        if (musicSound != null)
        {
            musicSource.clip = s.clip;
            musicSource.loop = true;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Background music clip is not assigned.");
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSound, x=> x.name == name);
        if (s != null)
        {
            sfxSource.PlayOneShot(s.clip);          
        }
        else
        {
            Debug.LogWarning("Background music clip is not assigned.");
        }
    }
}