using UnityEngine;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour
{
    [HideInInspector]
    public float timeSpent = 0;

    [HideInInspector]
    public bool mapCompleted = false;

    private Text textComponent;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
    }

    private void Update()
    {
        if(!mapCompleted)
        {
            timeSpent += Time.deltaTime;
            textComponent.text = timeSpent.ToString(".0", System.Globalization.CultureInfo.InvariantCulture) + " s";
        }
    }
}
