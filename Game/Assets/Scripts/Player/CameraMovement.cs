using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Transform playerTransform;
    private Vector3 offset;
    public float smoothSpeed = 10f;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
    }

    private void Start()
    {
        offset = new Vector3(0, 2, -10);
    }

    void FixedUpdate()
    {
        // update camera position
        Vector3 pos = playerTransform.position + offset;
        Vector3 initialPos = transform.position;
        initialPos.z = pos.z; // avoid lerping camera on z-axis
        Vector3 smoothedPos = Vector3.Lerp(initialPos, pos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPos;
    }

}
