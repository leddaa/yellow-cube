using UnityEngine;

public class Cheat : MonoBehaviour
{

    public float upForce = 1000;
    public Rigidbody body;

    private TimeTracker timeTracker;

    private void Awake()
    {
        timeTracker = GameObject.FindGameObjectWithTag("TimeTracker").GetComponent<TimeTracker>();
    }

    void Update()
    {
        if (Input.GetKey("r"))
        {
            body.AddForce(0, upForce * Time.deltaTime, 0 );
            timeTracker.timeSpent += 300 * Time.deltaTime;
        }
    }

}
