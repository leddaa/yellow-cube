using UnityEngine;

public class RotateLeft : MonoBehaviour
{

    public float speed = 50f;

    void Update()
    {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }

}
