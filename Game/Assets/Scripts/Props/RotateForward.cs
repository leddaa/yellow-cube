using UnityEngine;

public class RotateForward : MonoBehaviour
{

    public float speed = 50f;

    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }

}
