using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public static int SECONDS_TO_MICROSECONDS = 1000000;

    private AudioManager audioManager;
    public GameObject completionPanel;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>();
    }

    public void ShowCompletionPanel()
    {
        var x = Screen.width - (340 / 2);
        var y = Screen.height - (380 / 2);
        GameObject go = Instantiate(completionPanel, new Vector3(x, y, 0), Quaternion.identity);
        go.transform.SetParent(GameObject.Find("Canvas").transform);
    }

    public void EnterGoal()
    {
        GameObject.FindGameObjectWithTag(Tags.TIME_TRACKER).GetComponent<TimeTracker>().mapCompleted = true;

        int timeSpent = (int)(GameObject.FindGameObjectWithTag(Tags.TIME_TRACKER).GetComponent<TimeTracker>().timeSpent * SECONDS_TO_MICROSECONDS);
        Store.SetInt(StoreKeys.TimeSpent, timeSpent);

        var currentHighscore = Store.GetHighcore(SceneManager.GetActiveScene().name);
        if (currentHighscore == null || timeSpent < currentHighscore)
        {
            Store.SetHighscore(SceneManager.GetActiveScene().name, timeSpent);
            Store.SetBool(StoreKeys.IsNewHighscore, true);
        }
        else
        {
            Store.SetBool(StoreKeys.IsNewHighscore, false);
        }

        audioManager.Play(Audio.COMPLETE_SOUND);

        ShowCompletionPanel();

        // Unlock next level
        if (PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL) == Scenes.LEVEL_1)
        {
            PlayerPrefs.SetInt(PrefKeys.LEVEL_2_UNLOCKED, 1);
        }
        else if 
        (PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL) == Scenes.LEVEL_2)
        {
            PlayerPrefs.SetInt(PrefKeys.LEVEL_3_UNLOCKED, 1);
        }
        else if 
        (PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL) == Scenes.LEVEL_3)
        {
            PlayerPrefs.SetInt(PrefKeys.LEVEL_4_UNLOCKED, 1);
        }
        else if 
        (PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL) == Scenes.LEVEL_4)
        {
            PlayerPrefs.SetInt(PrefKeys.LEVEL_5_UNLOCKED, 1);
        }
        else if 
        (PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL) == Scenes.LEVEL_5)
        {
            PlayerPrefs.SetInt(PrefKeys.LEVEL_6_UNLOCKED, 1);
        }
        else if 
        (PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL) == Scenes.LEVEL_6)
        {
            PlayerPrefs.SetInt(PrefKeys.LEVEL_7_UNLOCKED, 1);
        }
        else if
        (PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL) == Scenes.LEVEL_7)
        {
            PlayerPrefs.SetInt(PrefKeys.LEVEL_8_UNLOCKED, 1);
        }
        else if
        (PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL) == Scenes.LEVEL_8)
        {
            PlayerPrefs.SetInt(PrefKeys.LEVEL_9_UNLOCKED, 1);
        }
        else if
        (PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL) == Scenes.LEVEL_9)
        {
            PlayerPrefs.SetInt(PrefKeys.LEVEL_10_UNLOCKED, 1);
        }
        else if
        (PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL) == Scenes.LEVEL_10)
        {
            PlayerPrefs.SetInt(PrefKeys.LEVEL_10_UNLOCKED, 1); // Level 11 when that time comes
        }
    }
}

