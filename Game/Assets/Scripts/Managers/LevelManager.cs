using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int DEPTH_OF_MAP = -1 ;

    [HideInInspector]
    public int TIME_TO_LOAD_NEXT_MAP = 0;

    private string nextScene;
    private Transform playerTransform;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioManager>();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void CompleteMap()
    {
        GameObject.FindGameObjectWithTag("TimeTracker").GetComponent<TimeTracker>().mapCompleted = true;

        FailManager.failCounter = 0;

        Invoke("LoadScene", TIME_TO_LOAD_NEXT_MAP);
        audioManager.Play("complete_sound");
    }

    // add listener for map finished loading
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    // remove listener for map finished loading
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nextScene = GameObject.FindGameObjectWithTag("NextScene").GetComponent<NextScene>().nextScene;
    }

    void Update()
    {
        // reload scene if player has fallen outside of the map
        if (playerTransform.position.y < DEPTH_OF_MAP)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
