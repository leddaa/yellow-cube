using UnityEngine;

public class DataFetch : MonoBehaviour
{
    private static bool hasFetched = false;

    private void Start()
    {
        if(!hasFetched)
        {
            GameObject.FindGameObjectWithTag(Tags.SERVER_MANAGER).GetComponent<ServerManager>().Fire(new MyClass("Data_fetch", 100000000, "Level 1"));
        }
        
        hasFetched = true;
    }
}
