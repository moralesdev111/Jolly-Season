using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] SceneManagement sceneManagement;
    public Sound[] musicSound, sfxSound;
    public AudioSource  musicSource, sfxSource;

    private void Start()
    {   
        CheckMusicSettingForScene();        
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
    private void CheckMusicSettingForScene()
    {
        if(sceneManagement.GetCurrentScene() == 0)
        {
            PlayMusic("Theme2");
        }
        else if(sceneManagement.GetCurrentScene() == 1)
        {
            PlayMusic("Theme");
        }
    }
}