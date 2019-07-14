using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public void MuteMusic()
    {
        GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>().ToggleMusic();
    }

    public void MuteGame()
    {
        Debug.Log("Mute game method not created.");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }

}
