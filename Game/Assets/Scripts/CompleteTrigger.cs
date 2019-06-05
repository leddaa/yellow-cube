using UnityEngine;

public class CompleteTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagement>().CompleteMap();
    }

}
