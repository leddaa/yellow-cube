using UnityEngine;

public class Rotate : MonoBehaviour
{

    private float speed = 50f;

    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }

}
