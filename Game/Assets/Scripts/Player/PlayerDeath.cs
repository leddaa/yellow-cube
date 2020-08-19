using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    public int explosionForce;
    public int explosionRadius;
    public int explosionUpward;
    public GameObject deathEffect;
    private Material material;
    private Camera camera;
    
    float cubesPivotDistance;
    Vector3 cubesPivot;

    private void Awake()
    {
        int index = PlayerPrefs.GetInt(PrefKeys.CURRENT_CHARACTER);
        material = GameObject.FindGameObjectWithTag(Tags.PLAYER_MANAGER).GetComponent<PlayerManager>().characters[index].deathMaterial;
        camera = (Camera)FindObjectOfType(typeof(Camera));
    }

    private void Start()
    {
        //Calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //Use this value to create pivor vector
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER_KILL)
        {
            Explode();
            Invoke("RestartLevel", 1.7f);
        }

        camera.GetComponent<CameraEffects>().Shake();
    }

    public void Explode()
    {
        // Death Particles
        Instantiate(deathEffect, transform.position, transform.rotation);

        //Make object disappear
        gameObject.SetActive(false);

        // Loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    CreatePiece(x, y, z);
                }
            }
        }

        // Get explotion position
        Vector3 explosionPos = transform.position;
        // Get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        // Add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    void CreatePiece(int x, int y, int z)
    {
        // Create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //Set piece position and scale
        piece.GetComponent<Renderer>().material = material;
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) -cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        // add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }
}
