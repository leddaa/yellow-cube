using UnityEngine;

public class FailWorkshop : MonoBehaviour
{

    Vector3 originalPos;
    public Rigidbody rigidBody;

    void start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    void Update()
    {
        if (transform.position.y < -10)
        {
            gameObject.transform.position = originalPos;
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            rigidBody.angularDrag = 0;
        }
    }

}
