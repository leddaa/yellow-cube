using UnityEngine;

public class RotateRight: MonoBehaviour
{

    private float speed = 25f;

    void Update()
    {
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }

}
