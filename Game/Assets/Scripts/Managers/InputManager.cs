using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

    private bool musicisplaying;
    void FixedUpdate()
    {

        // Exit to Main menu
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(Scenes.MAIN_MENU);
        }

        // Toggle music on/off
        if (Input.GetKeyDown("p"))
        {
            GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>().ToggleMusic();
        }

        // Restart level
        if (Input.GetKey("space"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PlayerPrefs.SetInt(Keys.FAIL_COUNTER, PlayerPrefs.GetInt(Keys.FAIL_COUNTER) + 1);
        }
    }

}
