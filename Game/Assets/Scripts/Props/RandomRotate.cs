using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{

   
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * 40f * Time.deltaTime);
        transform.Rotate(Vector3.left * 60f * Time.deltaTime);
        transform.Rotate(Vector3.up * 20f * Time.deltaTime);
    }
}
