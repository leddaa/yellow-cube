using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGravity : MonoBehaviour
{
    public GameObject pickupEffect;
    public float gravity;
    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        // Apply effect
        Physics.gravity = new Vector3(0, gravity, 0);

        // Disable gameObject
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;


        // Pause
        yield return new WaitForSeconds(duration);
        // Reverse effect
        Physics.gravity = new Vector3(0, -9.81f, 0);



        Destroy(gameObject);
    }
}
