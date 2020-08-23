using UnityEngine;

public class UIInitializer : MonoBehaviour
{
    public GameObject coinsPanel;

    private void Start()
    {
        var x = Screen.width - 100;
        var y = Screen.height - 40;
        GameObject go = Instantiate(coinsPanel, new Vector3(x, y, 0), Quaternion.identity);
        go.transform.SetParent(GameObject.Find("Canvas").transform);
    }
}
