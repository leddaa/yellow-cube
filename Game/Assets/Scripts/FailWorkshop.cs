using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FailWorkshop : MonoBehaviour


{


    Vector3 originalPos;
    public Rigidbody Rigidbody;


    void start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

    }

    void Update()
    {
        if (transform.position.y < -10)
        {
            gameObject.transform.position = originalPos;
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.angularVelocity = Vector3.zero;
            Rigidbody.angularDrag = 0;



        }
    }
}
