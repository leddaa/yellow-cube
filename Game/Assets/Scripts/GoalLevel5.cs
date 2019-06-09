using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalLevel5 : MonoBehaviour
{

    public TimeTracker timeTracker;

    void start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Goal")
        {
            timeTracker.mapCompleted = true;

            SceneManager.LoadScene("SampleScene");

            Debug.Log("Map changes to level 1");
        }
    }

}
