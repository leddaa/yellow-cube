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

        float timeSpent = (GameObject.FindGameObjectWithTag(Tags.TIME_TRACKER).GetComponent<TimeTracker>().timeSpent * SECONDS_TO_MICROSECONDS);
        PlayerPrefs.SetFloat(PrefKeys.COMPLETE_TIME, timeSpent);
        GameObject.FindGameObjectWithTag(Tags.TIME_TRACKER).GetComponent<TimeTracker>().mapCompleted = true;

        PlayerPrefs.SetInt(PrefKeys.TOTAL_FAIL_COUNTER, PlayerPrefs.GetInt(PrefKeys.FAIL_COUNTER));
        PlayerPrefs.SetInt(PrefKeys.FAIL_COUNTER, 0);

        audioManager.Play(Audio.COMPLETE_SOUND);

        checkHighscore((int)timeSpent);
        
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

    private void checkHighscore(int timeSpent)
    {
        string key;

        if(SceneManager.GetActiveScene().name == Scenes.LEVEL_1)
        {
            key = PrefKeys.HIGHSCORE_LEVEL_1;
        } else if(SceneManager.GetActiveScene().name == Scenes.LEVEL_2)
        {
            key = PrefKeys.HIGHSCORE_LEVEL_2;
        }
        else if (SceneManager.GetActiveScene().name == Scenes.LEVEL_3)
        {
            key = PrefKeys.HIGHSCORE_LEVEL_3;
        }
        else if (SceneManager.GetActiveScene().name == Scenes.LEVEL_4)
        {
            key = PrefKeys.HIGHSCORE_LEVEL_4;
        }
        else if (SceneManager.GetActiveScene().name == Scenes.LEVEL_5)
        {
            key = PrefKeys.HIGHSCORE_LEVEL_5;
        }
        else if (SceneManager.GetActiveScene().name == Scenes.LEVEL_6)
        {
            key = PrefKeys.HIGHSCORE_LEVEL_6;
        }
        else if (SceneManager.GetActiveScene().name == Scenes.LEVEL_7)
        {
            key = PrefKeys.HIGHSCORE_LEVEL_7;
        }
        else if (SceneManager.GetActiveScene().name == Scenes.LEVEL_8)
        {
            key = PrefKeys.HIGHSCORE_LEVEL_8;
        }
        else if (SceneManager.GetActiveScene().name == Scenes.LEVEL_9)
        {
            key = PrefKeys.HIGHSCORE_LEVEL_9;
        }
        else if (SceneManager.GetActiveScene().name == Scenes.LEVEL_10)
        {
            key = PrefKeys.HIGHSCORE_LEVEL_10;
        } else
        {
            throw new System.Exception();
        }

        Debug.Log(SceneManager.GetActiveScene().name + ": You spent " + (float)timeSpent / SECONDS_TO_MICROSECONDS + " seconds (" + timeSpent + ")");

        float highscore = PlayerPrefs.GetFloat(key);
        Debug.Log(SceneManager.GetActiveScene().name + ": Stored highscore pref: " + highscore / SECONDS_TO_MICROSECONDS + " seconds (" + highscore + ")");

        if (highscore == 0 || timeSpent < highscore) // Highscore doesnt exist or new score is better
        {
            PlayerPrefs.SetFloat(key, timeSpent);
            Debug.Log("New highscore set: " + timeSpent);

            MyClass myFireObject = new MyClass("Fudgehog", timeSpent, SceneManager.GetActiveScene().name);
            GameObject.FindGameObjectWithTag("ServerManager").GetComponent<ServerManager>().Fire(myFireObject);
        }
    }

}
