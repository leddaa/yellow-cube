using UnityEngine;

public class CompleteTrigger : MonoBehaviour
{

    public LevelManager levelManager;

    private void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        levelManager.CompleteMap();
    }

}
