using UnityEngine;

public class RotateLeft : MonoBehaviour
{
    public float speed = 50;

    void Update()
    {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}
