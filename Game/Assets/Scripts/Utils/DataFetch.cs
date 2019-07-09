using UnityEngine;

public class DataFetch : MonoBehaviour
{

    private static bool hasFetched = false;

    void Start()
    {
        if(!hasFetched)
        {
            Debug.Log("Data fetch");
            GameObject.FindGameObjectWithTag(Tags.SERVER_MANAGER).GetComponent<ServerManager>().Fire(new MyClass("bolle", 77777738, "Level 1"));
        }
        
        hasFetched = true;
    }

}
