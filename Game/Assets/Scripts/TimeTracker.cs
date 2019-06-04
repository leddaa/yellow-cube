using UnityEngine;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour
{

    public Text text;
   
    public float timeSpent = 0;
    public bool isDone;
    

    void start() {
        isDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDone) {
            timeSpent += Time.deltaTime;
            text.text = timeSpent.ToString("0") + " s";
           
            
        }

        
    }

}
