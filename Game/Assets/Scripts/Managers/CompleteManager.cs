using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteManager : MonoBehaviour
{
    public static int SECONDS_TO_MICROSECONDS = 1000000;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>();
    }

    public void CompleteMap()
    {
        PlayerPrefs.SetString(PrefKeys.PREVIOUS_LEVEL, SceneManager.GetActiveScene().name);

        int timeSpent = (int)(GameObject.FindGameObjectWithTag(Tags.TIME_TRACKER).GetComponent<TimeTracker>().timeSpent * SECONDS_TO_MICROSECONDS);
        PlayerPrefs.SetInt(PrefKeys.COMPLETE_TIME, timeSpent);
        GameObject.FindGameObjectWithTag(Tags.TIME_TRACKER).GetComponent<TimeTracker>().mapCompleted = true;

        Debug.Log("timespent: " + timeSpent);

        PlayerPrefs.SetInt(PrefKeys.TOTAL_FAIL_COUNTER, PlayerPrefs.GetInt(PrefKeys.FAIL_COUNTER));
        PlayerPrefs.SetInt(PrefKeys.FAIL_COUNTER, 0);

        audioManager.Play(Audio.COMPLETE_SOUND);

        SceneManager.LoadScene(Scenes.LEVEL_COMPLETE);

        // Get stars time

        // Get time for level failed
        PlayerPrefs.SetInt(PrefKeys.STAR_TIME_0, 0);

        // Set time and reward for Star 1
        PlayerPrefs.SetInt(PrefKeys.STAR_TIME_1, GameObject.FindGameObjectWithTag(Tags.LEVEL_DATA).GetComponent<LevelData>().oneStarsTime);
        PlayerPrefs.SetInt(PrefKeys.oneStarCoinsAmount, GameObject.FindGameObjectWithTag(Tags.LEVEL_DATA).GetComponent<LevelData>().oneStarsCoinsAmount);

        // Set time and reward for Star 2
        PlayerPrefs.SetInt(PrefKeys.STAR_TIME_2, GameObject.FindGameObjectWithTag(Tags.LEVEL_DATA).GetComponent<LevelData>().twoStarsTime);
        PlayerPrefs.SetInt(PrefKeys.twoStarCoinsAmount, GameObject.FindGameObjectWithTag(Tags.LEVEL_DATA).GetComponent<LevelData>().twoStarsCoinsAmount);

        // Set time and reward for Star 3
        PlayerPrefs.SetInt(PrefKeys.STAR_TIME_3, GameObject.FindGameObjectWithTag(Tags.LEVEL_DATA).GetComponent<LevelData>().threeStarsTime);
        PlayerPrefs.SetInt(PrefKeys.threeStarCoinsAmount, GameObject.FindGameObjectWithTag(Tags.LEVEL_DATA).GetComponent<LevelData>().threeStarsCoinsAmount);

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

