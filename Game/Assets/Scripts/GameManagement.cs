using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{

    public string nextScene;

    private Transform playerTransform;
    private AudioSource mapCompleteSound;
    public int time;


    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        mapCompleteSound = GameObject.FindGameObjectWithTag("MapCompleteSound").GetComponent<AudioSource>();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void CompleteMap()
    {
        GameObject.FindGameObjectWithTag("TimeTracker").GetComponent<TimeTracker>().isDone = true;
        FailManagement.failCounter = 0;
        mapCompleteSound.Play();
        

        Invoke("LoadScene", time);
    }

    void Update()
    {
        // reload scene if player has fallen outside of the map
        if (playerTransform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
