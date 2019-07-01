using UnityEngine;

public class NextLevel : MonoBehaviour
{

    public string nextLevel;

    private void Start()
    {
        PlayerPrefs.SetString(PrefKeys.NEXT_LEVEL, nextLevel);
    }

}
