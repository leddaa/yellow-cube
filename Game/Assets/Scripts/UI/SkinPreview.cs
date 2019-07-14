using UnityEngine;

public class SkinPreview : MonoBehaviour
{

    private MeshFilter meshFilter;
    private new Renderer renderer;
    private MeshFilter newMeshFilter;
    private PlayerManager playerManager;

    private void Awake()
    {
        meshFilter = GameObject.FindGameObjectWithTag(Tags.DUMMY_PLAYER).GetComponent<MeshFilter>();
        renderer = GameObject.FindGameObjectWithTag(Tags.DUMMY_PLAYER).GetComponent<Renderer>();
        playerManager = GameObject.FindGameObjectWithTag(Tags.PLAYER_MANAGER).GetComponent<PlayerManager>();
    }

    void Update()
    {
        int index = PlayerPrefs.GetInt(PrefKeys.DUMMY_CHARACTER);
        meshFilter.mesh = playerManager.characters[index].mesh;
        renderer.material = playerManager.characters[index].material;
    }

}
