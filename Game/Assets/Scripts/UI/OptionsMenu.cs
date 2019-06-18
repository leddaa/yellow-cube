using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public void MuteMusic()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().ToggleMusic();
    }

    public void MuteGame()
    {
        Debug.Log("Mute game method not created.");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
