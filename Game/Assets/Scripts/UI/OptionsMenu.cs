using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider MusicSlider { get; set; }
    public Slider SfxSlider { get; set; }

    private void Start()
    {
        MusicSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat(PrefKeys.MUSIC_VOLUME_LEVEL, 0.5f));
        SfxSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat(PrefKeys.SFX_VOLUME_LEVEL, 0.5f));
    }

    public void OnMusicSliderValueChanged()
    {
        GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>().SetMusicVolume(MusicSlider.value);
    }

    public void OnSFXSliderValueChanged()
    {
        Debug.Log(SfxSlider.value);
    }

    public void Apply()
    {
        PlayerPrefs.SetFloat(PrefKeys.MUSIC_VOLUME_LEVEL, MusicSlider.value);
        PlayerPrefs.SetFloat(PrefKeys.SFX_VOLUME_LEVEL, SfxSlider.value);
    }

    public void MainMenu()
    {
        GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>().
            SetMusicVolume(PlayerPrefs.GetFloat(PrefKeys.MUSIC_VOLUME_LEVEL));
        GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>().
            SetSFXVolume(PlayerPrefs.GetFloat(PrefKeys.SFX_VOLUME_LEVEL));

        SceneManager.LoadScene(Scenes.UI_MENU);
    }
}
