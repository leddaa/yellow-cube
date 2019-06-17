using UnityEngine;

public class NextLevel : MonoBehaviour
{

    public string nextLevel;

    private void Start()
    {
        PlayerPrefs.SetString("next_level", nextLevel);
    }

}
