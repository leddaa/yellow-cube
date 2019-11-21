using UnityEngine;
using UnityEngine.UI;

public class Cheat : MonoBehaviour
{
    public Material MaterialCheater { get; set; }
    public float UpwardForce { get; set; } = 1000;
    public Rigidbody Body { get; set; }

    private TimeTracker timeTracker;

    private void Awake()
    {
        timeTracker = GameObject.FindGameObjectWithTag(Tags.TIME_TRACKER).GetComponent<TimeTracker>();
    }

    private void Update()
    {
        if (Input.GetKey("f"))
        {
            Body.AddForce(0, UpwardForce * Time.deltaTime, 0 );
            timeTracker.timeSpent += 300 * Time.deltaTime;
            GameObject.FindGameObjectWithTag(Tags.CHEAT_TEXT).GetComponent<Text>().text = "Cheats Activated!";
            Renderer rend = GetComponent<Renderer>();
            rend.material = MaterialCheater;
        }
    }
}
