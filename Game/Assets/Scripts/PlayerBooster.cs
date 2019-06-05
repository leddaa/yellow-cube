
// Boosting the player up. (Upforce)

using UnityEngine;

public class PlayerBooster : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Boost(float upForce)
    { 
        rb.AddForce(0, upForce * Time.deltaTime, 0);
    }
}

