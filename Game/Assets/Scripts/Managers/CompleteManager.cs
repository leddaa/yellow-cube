using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteManager : MonoBehaviour
{

    private AudioManager audioManager;
    

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>();
        
    }

    public void CompleteMap()
    {

        PlayerPrefs.SetString(Keys.PREVIOUS_LEVEL, SceneManager.GetActiveScene().name);
        Debug.Log(PlayerPrefs.GetString(Keys.PREVIOUS_LEVEL));
        Debug.Log(SceneManager.GetActiveScene().name);
        

        PlayerPrefs.SetFloat(Keys.COMPLETE_TIME, GameObject.FindGameObjectWithTag(Tags.TIME_TRACKER).GetComponent<TimeTracker>().timeSpent);
        GameObject.FindGameObjectWithTag(Tags.TIME_TRACKER).GetComponent<TimeTracker>().mapCompleted = true;

        PlayerPrefs.SetInt(Keys.TOTAL_FAIL_COUNTER, PlayerPrefs.GetInt(Keys.FAIL_COUNTER));
        PlayerPrefs.SetInt(Keys.FAIL_COUNTER, 0);

        audioManager.Play(Audio.COMPLETE_SOUND);
        
        SceneManager.LoadScene(Scenes.MAP_COMPLETE);


    }

}
