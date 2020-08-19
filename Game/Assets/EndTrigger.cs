using System.Diagnostics;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public CompleteManager completeManager;
    
    void OnTriggerEnter()
    {
        completeManager.CompleteMap();
        
    }

}
