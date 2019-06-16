using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    private static AudioManager Instance = null;

    [HideInInspector]
    public AudioSource musicSource;
    public AudioClip musicClip;
    public Sound[] sounds;
    private bool musicisplaying;


    void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        // If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        // Set AudioManager to DontDestroyOnLoad so that it won't be destroyed when reloading the scene.
        DontDestroyOnLoad(gameObject);

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.loop = true;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
        }

        musicSource.Play();
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Update()
    {

        
        if (Input.GetKey("p"))
        {
            if (musicisplaying)
            {
                musicSource.Stop();
                musicisplaying = false;
            } else
            {
                musicSource.Play();
                musicisplaying = true;
            }
               
        }
    }
}
 