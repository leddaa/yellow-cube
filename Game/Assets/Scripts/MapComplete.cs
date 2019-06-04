using UnityEngine;
using UnityEngine.SceneManagement;

public class MapComplete : MonoBehaviour
{

    public TimeTracker timeTracker;
    public string sceneName;

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Goal")
        {
            timeTracker.isDone = true;
            FailManagement.failCounter = 0;

            Invoke("LoadScene", 1);
        }
    }

}
