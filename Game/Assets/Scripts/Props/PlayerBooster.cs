using UnityEngine;

public class PlayerBooster : MonoBehaviour
{
    private Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Boost(float upForce)
    { 
        rigidBody.AddForce(0, upForce * Time.deltaTime, 0);
    }
}
