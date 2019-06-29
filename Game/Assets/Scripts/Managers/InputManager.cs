using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    private bool musicisplaying;
    private bool leaderBoardEnabled = false;
    void Update()
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

        // Restart level/nextlevel
        if (Input.GetKey("space"))
        {
            if (SceneManager.GetActiveScene().name != Scenes.LEVEL_COMPLETE)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                PlayerPrefs.SetInt(Keys.FAIL_COUNTER, PlayerPrefs.GetInt(Keys.FAIL_COUNTER) + 1);
            } else if (PlayerPrefs.GetInt(Keys.STAR_TIME_0) != 0)
            {
                SceneManager.LoadScene(PlayerPrefs.GetString(Keys.NEXT_LEVEL));
                
            } else 
            {
                SceneManager.LoadScene(PlayerPrefs.GetString(Keys.PREVIOUS_LEVEL));
            }
            
        }

        if(Input.GetKeyDown("tab"))
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
