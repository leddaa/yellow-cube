using System.Diagnostics;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GoalManager completeManager;
    
    void OnTriggerEnter()
    {
        completeManager.EnterGoal();
        
    }

}
