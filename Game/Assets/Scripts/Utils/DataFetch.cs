using UnityEngine;

public class DataFetch : MonoBehaviour
{

    private static bool hasFetched = false;

    void Start()
    {
        if(!hasFetched)
        {
            Debug.Log("Data fetch");
            GameObject.FindGameObjectWithTag(Tags.SERVER_MANAGER).GetComponent<ServerManager>().Fire(new MyClass("Data_fetch", 100000000, "Level 1"));
        }
        
        hasFetched = true;
    }

}
