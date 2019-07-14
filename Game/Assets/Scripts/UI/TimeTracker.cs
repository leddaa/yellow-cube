using UnityEngine;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour
{

    [HideInInspector]
    public float timeSpent = 0;
    [HideInInspector]
    public bool mapCompleted = false;

    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        if(!mapCompleted)
        {
            timeSpent += Time.deltaTime;
            text.text = timeSpent.ToString(".0", System.Globalization.CultureInfo.InvariantCulture) + " s";
        }
    }

}
