using UnityEngine;

public class Jump : MonoBehaviour

{

    public Rigidbody body;
    private TimeTracker timeTracker;
    
    public float upForce = 1000;

    private void Start()
    {
        timeTracker = GameObject.FindGameObjectWithTag("TimeTracker").GetComponent<TimeTracker>();
    }

    void Update()
    {
        if (Input.GetKey("r"))
        {
            body.AddForce(0, upForce * Time.deltaTime, 0 );
            timeTracker.timeSpent += Time.deltaTime;
            timeTracker.timeSpent += 30;
        }
    }

}
