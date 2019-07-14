using UnityEngine;
using UnityEngine.SceneManagement;

public class FailManager : MonoBehaviour
{

    public static int DEPTH_OF_MAP = -1;

    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
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
            playerTransform = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
    }

    void Update()
    {
        if (playerTransform.position.y < DEPTH_OF_MAP)
        {
            int failCounter = PlayerPrefs.GetInt(PrefKeys.FAIL_COUNTER) + 1;
            PlayerPrefs.SetInt(PrefKeys.FAIL_COUNTER, failCounter);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
