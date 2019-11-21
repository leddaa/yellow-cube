using UnityEngine;

public class RotateRight: MonoBehaviour
{
    public float speed = 25;

    private void Update()
    {
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }
}
