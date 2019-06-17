using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteManager : MonoBehaviour
{

    public static string NEXT_SCENE = "MapCompleteMenu";

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void CompleteMap()
    {
        GameObject.FindGameObjectWithTag("TimeTracker").GetComponent<TimeTracker>().mapCompleted = true;
        FailManager.failCounter = 0;
        audioManager.Play("complete_sound");
        SceneManager.LoadScene(NEXT_SCENE);
    }

}
