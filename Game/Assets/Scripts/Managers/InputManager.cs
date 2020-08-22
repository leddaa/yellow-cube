using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private readonly bool musicisplaying;
    private bool leaderBoardEnabled = false;

    private GameObject loginScreen;

    private void Start()
    {
        loginScreen = GameObject.FindGameObjectWithTag(Tags.CANVAS_LOGIN);
    }

    private void Update()
    {
        // Exit to Main menu
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(Scenes.UI_MENU);
        }

        // Toggle music on/off
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(loginScreen.activeSelf == false)
            {
                GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>().ToggleMusic();
            }
        }

        // Restart/retry
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
            if (SceneManager.GetActiveScene().name == Scenes.LEVEL_COMPLETE) // Restart level
            {
                SceneManager.LoadScene(PlayerPrefs.GetString(PrefKeys.NEXT_LEVEL));
            }
        }

        // Reset player prefs
        if (Input.GetKeyDown(KeyCode.M) && Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("Resetting PlayerPrefs");
            PlayerPrefs.DeleteAll();
        }

        // Toggle leaderboard
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (SceneManager.GetActiveScene().name != Scenes.UI_MENU &&
                SceneManager.GetActiveScene().name != Scenes.OPTIONS_MENU &&
                SceneManager.GetActiveScene().name != Scenes.SHOP_MENU &&
                SceneManager.GetActiveScene().name != Scenes.SKINS_MENU &&
                SceneManager.GetActiveScene().name != Scenes.LEVEL_COMPLETE)
            {
                GameObject.FindGameObjectWithTag("LevelText").GetComponent<Text>().text = SceneManager.GetActiveScene().name;

                if (leaderBoardEnabled)
                {
                    Text[] texts = GameObject.FindGameObjectWithTag(Tags.LEADERBOARD).GetComponent<Image>().GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        t.enabled = false;
                    }

                    GameObject.FindGameObjectWithTag(Tags.LEADERBOARD).GetComponent<Image>().enabled = false;
                    leaderBoardEnabled = false;
                }
                else
                {
                    Text[] texts = GameObject.FindGameObjectWithTag(Tags.LEADERBOARD).GetComponent<Image>().GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        t.enabled = true;
                    }

                    GameObject.FindGameObjectWithTag(Tags.LEADERBOARD).GetComponent<Image>().enabled = true;
                    leaderBoardEnabled = true;
                }
            }
        }
    }
}