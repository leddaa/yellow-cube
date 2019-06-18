using UnityEngine;

public class InitCharacter : MonoBehaviour
{

    public Character[] characters;

    private void Start()
    {
        int index = PlayerPrefs.GetInt(Keys.CURRENT_CHARACTER);
        GetComponent<MeshFilter>().mesh = characters[index].mesh;
        GetComponent<Renderer>().material = characters[index].material;
    }

}
