﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{

    private float TRAIL_EFFECT_TRIGGER_SPEED = 32f;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER_COIN)
        {
            // Destroy(GameObject.FindGameObjectWithTag(Tags.PLAYER_COIN));
            GameObject.FindGameObjectWithTag(Tags.PLAYER_COIN).SetActive(false);
            Debug.Log("Ding ding! Coin picked up!");
        }

    }
}
