using System.Collections;
using UnityEngine;

public class PowerUpScale : MonoBehaviour
{

    public GameObject pickupEffect;
    public float multiplier = 1.5f;
    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Pickup(other) );
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        // Apply effect
        player.transform.localScale *= multiplier;

        // Disable gameObject
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;


        // Pause
        yield return new WaitForSeconds(duration);
        // Reverse effect
        player.transform.localScale /= multiplier;

        Destroy(gameObject);
    }

}
