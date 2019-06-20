using UnityEngine;

public class RotateDown : MonoBehaviour
{

    public float speed = 75f;

    void Update()
    {
        transform.Rotate(Vector3.down * speed * Time.deltaTime);
    }

}
