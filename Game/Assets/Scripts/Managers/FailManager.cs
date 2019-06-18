using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailManager : MonoBehaviour
{
    public static int DEPTH_OF_MAP = -1;

    private Transform playerTransform;

    public static string FAIL_COUNTER_KEY = "failCounter";

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(PlayerPrefs.GetInt(FAIL_COUNTER_KEY) + " Awake");
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
            GameObject.FindGameObjectWithTag("FailText").GetComponent<Text>().text = PlayerPrefs.GetInt(FAIL_COUNTER_KEY) + " fails";
    }

    void Update()
    {
        if (playerTransform.position.y < DEPTH_OF_MAP)
        {
            Debug.Log(PlayerPrefs.GetInt(FAIL_COUNTER_KEY));
            int failCounter = PlayerPrefs.GetInt(FAIL_COUNTER_KEY) + 1;
            Debug.Log(failCounter + " Before");
            PlayerPrefs.SetInt(FAIL_COUNTER_KEY, failCounter);
            Debug.Log(failCounter + " after");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
