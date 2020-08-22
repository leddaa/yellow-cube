using UnityEditor;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{

    public float Speed_Up;
    public float Speed_Back;
    public float Speed_Left;
    public float Speed_Right;

    private void Update()
    {
        transform.Rotate(Vector3.back * Speed_Back * Time.deltaTime);
        transform.Rotate(Vector3.left * Speed_Left * Time.deltaTime);
        transform.Rotate(Vector3.right * Speed_Right * Time.deltaTime);
        transform.Rotate(Vector3.up * Speed_Up * Time.deltaTime);
    }
}
