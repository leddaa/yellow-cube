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

        PlayerPrefs.SetInt(PrefKeys.TOTAL_FAIL_COUNTER, PlayerPrefs.GetInt(PrefKeys.FAIL_COUNTER));
        PlayerPrefs.SetInt(PrefKeys.FAIL_COUNTER, 0);

        audioManager.Play(Audio.COMPLETE_SOUND);
        
        SceneManager.LoadScene(Scenes.LEVEL_COMPLETE);

        // Get stars time

        // Get time for level failed
        PlayerPrefs.SetInt(PrefKeys.STAR_TIME_0, 0);

        // Get time for Star 1
        PlayerPrefs.SetInt(PrefKeys.STAR_TIME_1, GameObject.FindGameObjectWithTag(Tags.LEVEL_DATA).GetComponent<LevelData>().oneStars);

        // Get time for Star 2
        PlayerPrefs.SetInt(PrefKeys.STAR_TIME_2, GameObject.FindGameObjectWithTag(Tags.LEVEL_DATA).GetComponent<LevelData>().twoStars);

        // Get time for Star 3
        PlayerPrefs.SetInt(PrefKeys.STAR_TIME_3, GameObject.FindGameObjectWithTag(Tags.LEVEL_DATA).GetComponent<LevelData>().threeStars);
    }

}
