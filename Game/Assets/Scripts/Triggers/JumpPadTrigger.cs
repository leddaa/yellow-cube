// Triggers PlayerBooster (Upforce)
using UnityEngine;

public class JumpPadTrigger : MonoBehaviour
{

    public float upForce;

    private AudioSource bounceSound;
    private PlayerBooster playerBooster;

    void Awake()
    {
        bounceSound = GetComponent<AudioSource>();
        playerBooster = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerBooster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerBooster.Boost(upForce);
        bounceSound.Play();
    }

}
