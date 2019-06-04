using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody body;

    public float forwardForce = 1000f;
    public float sideForce = 1000f;

    void FixedUpdate()
    {
        if(Input.GetKey("w") || Input.GetKey("up")) {
            body.AddForce(0, 0, forwardForce * Time.deltaTime);
        }else if(Input.GetKey("s") || Input.GetKey("down")) {
            body.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        if(Input.GetKey("a") || Input.GetKey("left")) {
            body.AddForce(-sideForce * Time.deltaTime, 0, 0);
        } else if(Input.GetKey("d") || Input.GetKey("right")) {
            body.AddForce(sideForce * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey("space")) {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }

        if(Input.GetKey("escape")) {
            Application.Quit();
        }
    }

}
