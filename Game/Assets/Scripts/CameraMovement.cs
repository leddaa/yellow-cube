using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Transform playerTransform;
    public Vector3 offset;
    public float smoothSpeed = 10f;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        // update camera position
        Vector3 pos = playerTransform.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, pos, smoothSpeed * Time.deltaTime);
        Debug.Log(smoothSpeed * Time.deltaTime);
        transform.position = smoothedPos;
    }

}
