using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailManager : MonoBehaviour
{

    public static int failCounter;

    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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
        GameObject.FindGameObjectWithTag("FailText").GetComponent<Text>().text = failCounter.ToString() + " fails";
    }

    void Update()
    {
        if (playerTransform.position.y < LevelManager.DEPTH_OF_MAP)
            failCounter++;
    }

}
