using UnityEngine;

public class NextLevel : MonoBehaviour
{

    public string nextLevel;

    private void Start()
    {
        PlayerPrefs.SetString(Keys.NEXT_LEVEL, nextLevel);
    }

}
