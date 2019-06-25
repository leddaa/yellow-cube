using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{

    private float TRAIL_EFFECT_TRIGGER_SPEED = 42f;
    private Rigidbody rigidBody;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        Debug.Log(rigidBody.velocity.magnitude);
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
