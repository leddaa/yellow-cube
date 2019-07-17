using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        musicSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat(PrefKeys.MUSIC_VOLUME_LEVEL, 0.5f));
        sfxSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat(PrefKeys.SFX_VOLUME_LEVEL, 0.5f));
    }

    public void OnMusicSliderValueChanged()
    {
        GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>().SetMusicVolume(musicSlider.value);
    }

    public void OnSFXSliderValueChanged()
    {
        Debug.Log(sfxSlider.value);
    }

    public void Apply()
    {
        PlayerPrefs.SetFloat(PrefKeys.MUSIC_VOLUME_LEVEL, musicSlider.value);
        PlayerPrefs.SetFloat(PrefKeys.SFX_VOLUME_LEVEL, sfxSlider.value);
    }

    public void MainMenu()
    {
        GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>().
            SetMusicVolume(PlayerPrefs.GetFloat(PrefKeys.MUSIC_VOLUME_LEVEL));
        GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>().
            SetSFXVolume(PlayerPrefs.GetFloat(PrefKeys.SFX_VOLUME_LEVEL));

        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }

}
