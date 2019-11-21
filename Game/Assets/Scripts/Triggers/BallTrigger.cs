using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag(Tags.PLAYER_CLIP).SetActive(false);
        var rigidBodies = GameObject.FindGameObjectWithTag(Tags.DOOR).GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = false;
        }
    }
}
