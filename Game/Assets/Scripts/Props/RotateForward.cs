using UnityEngine;

public class RotateForward : MonoBehaviour
{
    public float speed = 50;

    private void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
