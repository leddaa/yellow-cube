using UnityEngine;

public class ForceUp : MonoBehaviour
{
    public float upForce;

    private PlayerBooster playerBooster;

    void Awake()
    {  
        playerBooster = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerBooster>();
    }

    private void OnTriggerStay(Collider other)
    {
        playerBooster.Boost(upForce);
    }
}
