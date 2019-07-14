using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Character
{

    public Mesh mesh;
    public Material material;
    public Material deathMaterial;

}

public class PlayerManager : MonoBehaviour
{

    public Character[] characters;
    private MeshFilter meshFilter;
    private new Renderer renderer;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != Scenes.SKINS_MENU)
        {
            meshFilter = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<MeshFilter>();
            renderer = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Renderer>();
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != Scenes.SKINS_MENU)
        {
            int index = PlayerPrefs.GetInt(PrefKeys.CURRENT_CHARACTER);
            meshFilter.mesh = characters[index].mesh;
            renderer.material = characters[index].material;
        }
    }

}
