using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;

    private float FORWARD_FORCE = 1000f;
    private float SIDE_FORCE = 1000f;
    float horizontalMove = 0f;
    float verticalMove = 0f;

    private float MAX_VELOCITY = 35f;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        horizontalMove = (( 1.4f * joystick.Horizontal) * SIDE_FORCE);
        verticalMove =  ((1.4f * joystick.Vertical) * FORWARD_FORCE);

        //Debug.Log("Joystick.Vertical = " + joystick.Vertical);
        //Debug.Log("verticalMove: " + verticalMove);
        //Debug.Log("Joystick.Horizontal = " + joystick.Horizontal);
        //Debug.Log("horizontalMove: " + horizontalMove);

        if(Input.GetKey("w") || Input.GetKey("up") || joystick.Vertical >= 0.05f) {
            rigidBody.AddForce(0, 0, verticalMove * Time.deltaTime);
        }else if(Input.GetKey("s") || Input.GetKey("down") || joystick.Vertical <= -0.05f) {
            rigidBody.AddForce(0, 0, verticalMove * Time.deltaTime);
        }

        if(Input.GetKey("a") || Input.GetKey("left") || joystick.Horizontal <= -0.01f) {
            rigidBody.AddForce(horizontalMove * Time.deltaTime, 0, 0);
        } else if(Input.GetKey("d") || Input.GetKey("right") || joystick.Horizontal >= 0.01f) {
            rigidBody.AddForce(horizontalMove * Time.deltaTime, 0, 0);
        }

        

        if(rigidBody.velocity.magnitude > MAX_VELOCITY)
            rigidBody.velocity = rigidBody.velocity.normalized * MAX_VELOCITY;
    }

}
