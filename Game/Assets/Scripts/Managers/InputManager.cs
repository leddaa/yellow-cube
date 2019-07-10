using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    private bool musicisplaying;
    private bool leaderBoardEnabled = false;

    private void Update()
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
                PlayerPrefs.SetInt(PrefKeys.FAIL_COUNTER, PlayerPrefs.GetInt(PrefKeys.FAIL_COUNTER) + 1);
            } else if (SceneManager.GetActiveScene().name == Scenes.LEVEL_COMPLETE)
            {
                SceneManager.LoadScene(PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL));
            }
        }
        
        if (Input.GetKey("space"))
        {
            if (SceneManager.GetActiveScene().name == Scenes.LEVEL_COMPLETE && PlayerPrefs.GetInt(PrefKeys.STAR_TIME_0) != 0) // Restart level
            {
                SceneManager.LoadScene(PlayerPrefs.GetString(PrefKeys.NEXT_LEVEL));
            }
            else if (SceneManager.GetActiveScene().name == Scenes.LEVEL_COMPLETE && PlayerPrefs.GetInt(PrefKeys.STAR_TIME_0) == 0) // Go to next level
            {
                SceneManager.LoadScene(PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL));
            }
        }

        // Publish and receive data
        if(Input.GetKeyDown("l"))
        {
            GameObject.FindGameObjectWithTag(Tags.SERVER_MANAGER).GetComponent<ServerManager>().Fire(new MyClass("donut", 77777738, "Level 1"));
        }

        // Reset player prefs
        if (Input.GetKeyDown("m"))
        {
            GameObject.FindGameObjectWithTag(Tags.SERVER_MANAGER).GetComponent<ServerManager>().ResetPrefs();
        }

        // Toggle leaderboard
        if (Input.GetKeyDown("tab"))
        {
            if(SceneManager.GetActiveScene().name != Scenes.MAIN_MENU &&
                SceneManager.GetActiveScene().name != Scenes.OPTIONS_MENU &&
                SceneManager.GetActiveScene().name != Scenes.SHOP_MENU &&
                SceneManager.GetActiveScene().name != Scenes.SKINS_MENU &&
                SceneManager.GetActiveScene().name != Scenes.LEVEL_COMPLETE)
            {
                GameObject.FindGameObjectWithTag("LevelText").GetComponent<Text>().text = SceneManager.GetActiveScene().name;

                if (leaderBoardEnabled)
                {
                    Text[] texts = GameObject.FindGameObjectWithTag("LeaderBoard").GetComponent<Image>().GetComponentsInChildren<Text>();
                    foreach(Text t in texts)
                    {
                        t.enabled = false;
                    }

                    GameObject.FindGameObjectWithTag("LeaderBoard").GetComponent<Image>().enabled = false;
                    leaderBoardEnabled = false;
                }
                else
                {
                    Text[] texts = GameObject.FindGameObjectWithTag("LeaderBoard").GetComponent<Image>().GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        t.enabled = true;
                    }

                    GameObject.FindGameObjectWithTag("LeaderBoard").GetComponent<Image>().enabled = true;
                    leaderBoardEnabled = true;
                }
            }
        }
    }

    }
