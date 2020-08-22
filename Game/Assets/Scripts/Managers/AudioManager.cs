using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    public AudioClip clip;
    public string name;

    [HideInInspector]
    public AudioSource source;
}

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup musicAudioMixerGroup;
    public AudioMixerGroup sfxAudioMixerGroup;

    [HideInInspector]
    public AudioSource musicSource;
    public AudioClip musicClip;
    public Sound[] sounds;
    public bool musicOnByDefault;
    private bool musicisplaying;

    private static AudioManager _instance = null;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        musicisplaying = false;

        // Set AudioManager to DontDestroyOnLoad so that it won't be destroyed when reloading the scene.
        DontDestroyOnLoad(gameObject);

        // Init music
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.outputAudioMixerGroup = musicAudioMixerGroup;

        if (musicOnByDefault)
            musicSource.Play();

        // Init sounds
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = sfxAudioMixerGroup;
        }
    }

    private void Start()
    {
        SetMusicVolume(PlayerPrefs.GetFloat(PrefKeys.MUSIC_VOLUME_LEVEL));
        SetSFXVolume(PlayerPrefs.GetFloat(PrefKeys.SFX_VOLUME_LEVEL));
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    // Toggle music on/off - Called in inputManager.
    public void ToggleMusic()
    {
        if (musicisplaying)
        {
            musicisplaying = false;
            musicSource.Stop();
        } else
        {
            musicisplaying = true;
            musicSource.Play();
        }
    }

    public void SetMusicVolume(float level)
    {
        musicAudioMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log(level) * 20);
    }

    public void SetSFXVolume(float level)
    {
        musicAudioMixerGroup.audioMixer.SetFloat("SFXVolume", Mathf.Log(level) * 20);
    }
}
 