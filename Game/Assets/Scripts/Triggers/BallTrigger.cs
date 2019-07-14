using UnityEngine;

public class BallTrigger : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag(Tags.DOOR).SetActive(false);
    }

}
