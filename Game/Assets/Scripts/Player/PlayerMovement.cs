using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly float FORWARD_FORCE = 1000f;
    private readonly float SIDE_FORCE = 1000f;
    private readonly float MAX_VELOCITY = 35f;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rigidBody.AddForce(0, 0, FORWARD_FORCE * Time.deltaTime);
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rigidBody.AddForce(0, 0, -FORWARD_FORCE * Time.deltaTime);
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigidBody.AddForce(-SIDE_FORCE * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigidBody.AddForce(SIDE_FORCE * Time.deltaTime, 0, 0);
        }

        if (rigidBody.velocity.magnitude > MAX_VELOCITY)
            rigidBody.velocity = rigidBody.velocity.normalized * MAX_VELOCITY;
    }
}
