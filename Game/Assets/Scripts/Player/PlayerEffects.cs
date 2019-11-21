using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    private readonly float TRAIL_EFFECT_TRIGGER_SPEED = 32;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
   
    void Update()
    {
        if (rigidBody.velocity.magnitude > TRAIL_EFFECT_TRIGGER_SPEED)
        {
            GameObject.FindGameObjectWithTag(Tags.PLAYER_PARTICLESYSTEM).GetComponent<ParticleSystem>().Play();
        }
        else
        {
            GameObject.FindGameObjectWithTag(Tags.PLAYER_PARTICLESYSTEM).GetComponent<ParticleSystem>().Stop();
        }
    }
}
