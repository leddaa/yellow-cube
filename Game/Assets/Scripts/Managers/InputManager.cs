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

        // Restart/retry
        if (Input.GetKeyDown("r"))
        {
            if (SceneManager.GetActiveScene().name != Scenes.LEVEL_COMPLETE)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                PlayerPrefs.SetInt(Keys.FAIL_COUNTER, PlayerPrefs.GetInt(Keys.FAIL_COUNTER) + 1);
            }
        }
        
            

            // Restart level/nextlevel
            if (Input.GetKey("space"))
            {
                if (SceneManager.GetActiveScene().name == Scenes.LEVEL_COMPLETE && PlayerPrefs.GetInt(Keys.STAR_TIME_0) != 0)
                {
                    SceneManager.LoadScene(PlayerPrefs.GetString(Keys.NEXT_LEVEL));
            } else if (SceneManager.GetActiveScene().name == Scenes.LEVEL_COMPLETE && PlayerPrefs.GetInt(Keys.STAR_TIME_0) == 0)
                {
                    SceneManager.LoadScene(PlayerPrefs.GetString(Keys.PREVIOUS_LEVEL));
                }   


        }
    }

    }
