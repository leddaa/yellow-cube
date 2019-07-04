using UnityEngine;

public class DataFetch : MonoBehaviour
{

    void Start()
    {
        Debug.Log("Data fetch");
        GameObject.FindGameObjectWithTag(Tags.SERVER_MANAGER).GetComponent<ServerManager>().Fire(new MyClass("bolle", 77777738, "Level 1"));
    }

}
