using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        // exit to main menu
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(Scenes.UI_MENU);

        // toggle music on/off
        if (Input.GetKeyDown(KeyCode.P))
            GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>().ToggleMusic();

        // restart/retry
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (SceneManager.GetActiveScene().name != Scenes.UI_MENU)
            {
                if (SceneManager.GetActiveScene().name != Scenes.LEVEL_COMPLETE)
                {
                    PlayerPrefs.SetInt(PrefKeys.FAIL_COUNTER, PlayerPrefs.GetInt(PrefKeys.FAIL_COUNTER) + 1);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                else
                {
                    SceneManager.LoadScene(PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL));
                }
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().name == Scenes.LEVEL_COMPLETE) // restart level
                SceneManager.LoadScene(PlayerPrefs.GetString(PrefKeys.NEXT_LEVEL));
        }

        // reset player prefs
        if (Input.GetKeyDown(KeyCode.M) && Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("Resetting PlayerPrefs");
            PlayerPrefs.DeleteAll();
        }
    }
}