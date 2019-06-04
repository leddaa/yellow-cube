using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float speed = 50f;

    void Update()
    {

        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        
    }
}
