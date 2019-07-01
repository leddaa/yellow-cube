using UnityEngine;
using UnityEngine.SceneManagement;

public class InitCharacter : MonoBehaviour
{

    public Character[] characters;

    private void Start()
    {
        int index = PlayerPrefs.GetInt(PrefKeys.CURRENT_CHARACTER);
        GetComponent<MeshFilter>().mesh = characters[index].mesh;
        GetComponent<Renderer>().material = characters[index].material;

        
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == Scenes.SKINS_MENU)
        {
            int index = PlayerPrefs.GetInt(PrefKeys.CURRENT_CHARACTER);
            GetComponent<MeshFilter>().mesh = characters[index].mesh;
            GetComponent<Renderer>().material = characters[index].material;
        }
    }
}
