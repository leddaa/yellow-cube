using UnityEngine;

public class CompleteTrigger : MonoBehaviour
{

    public CompleteManager completeManager;

    private void Awake()
    {
        completeManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<CompleteManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        completeManager.CompleteMap();
    }

}
