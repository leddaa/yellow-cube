using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpBoost : MonoBehaviour


{

    public Rigidbody body;
    public float upForce;

    void start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "JumpBoost")
        {

            body.AddForce(0, upForce * Time.deltaTime, 0);
            Debug.Log(Time.deltaTime.ToString());

        }
    }

}
