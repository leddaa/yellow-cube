using System.Collections;
using UnityEngine;

public class PowerUpChangeMesh : MonoBehaviour
{
    public GameObject pickupEffect;
    public float ballSize = 1;
    public float duration = 5;
    public Mesh mesh;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    private IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);


        // Play sound
        audioManager.Play(Audio.POWERUP_SOUND);

        // Apply effect
        Mesh initialMesh = player.GetComponent<MeshFilter>().mesh;

        player.GetComponent<MeshFilter>().mesh = mesh;
        player.GetComponent<MeshCollider>().sharedMesh = mesh;

        player.transform.localScale *= ballSize;


        // Disable gameObject
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        // Pause
        yield return new WaitForSeconds(duration);

        // Reverse effect
        player.GetComponent<MeshFilter>().mesh = initialMesh;
        player.GetComponent<MeshCollider>().sharedMesh = initialMesh;
        player.transform.localScale /= ballSize;

        Destroy(gameObject);
    }
}
