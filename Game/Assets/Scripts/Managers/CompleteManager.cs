using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteManager : MonoBehaviour
{

    public static string NEXT_SCENE = "MapCompleteMenu";
    public static string TOTAL_FAIL_COUNTER_KEY = "totalFailCounter";

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }

    public void CompleteMap()
    {
        PlayerPrefs.SetFloat("CompleteTime", GameObject.FindGameObjectWithTag("TimeTracker").GetComponent<TimeTracker>().timeSpent);
        GameObject.FindGameObjectWithTag("TimeTracker").GetComponent<TimeTracker>().mapCompleted = true;

        PlayerPrefs.SetInt(TOTAL_FAIL_COUNTER_KEY, PlayerPrefs.GetInt(FailManager.FAIL_COUNTER_KEY));
        PlayerPrefs.SetInt(FailManager.FAIL_COUNTER_KEY, 0);
        Debug.Log(FailManager.FAIL_COUNTER_KEY);

        audioManager.Play("complete_sound");
        
        SceneManager.LoadScene(NEXT_SCENE);


    }

}
