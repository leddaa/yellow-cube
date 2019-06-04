using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpBoostMedium : MonoBehaviour


{

    public Rigidbody body;
    public float upForce;
    public AudioSource bounceSource;


    void start()
    {
        bounceSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "JumpBoostMedium")
        {

            body.AddForce(0, upForce * Time.deltaTime, 0);
            bounceSource.Play();
            
           

        }
    }

}
