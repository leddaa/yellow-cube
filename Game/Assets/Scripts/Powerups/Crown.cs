using UnityEngine;

public class Crown : MonoBehaviour
{

    Transform playerTransform;
    Vector3 offset = new Vector3(0, 1, 0);

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
    }

    private void Update()
    {
        transform.position = playerTransform.position + offset;
    }

}
