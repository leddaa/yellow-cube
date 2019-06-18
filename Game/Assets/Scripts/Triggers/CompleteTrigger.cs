using UnityEngine;

public class CompleteTrigger : MonoBehaviour
{

    public CompleteManager completeManager;

    private void Awake()
    {
        completeManager = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<CompleteManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        completeManager.CompleteMap();
    }

}
