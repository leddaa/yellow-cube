using UnityEngine;

public class LevelData : MonoBehaviour
{

    [Header("Stars Time")]
    public int oneStars;
    public int twoStars;
    public int threeStars;

    [Header("Next Level")]
    public string nextLevel;

    private void Start()
    {
        PlayerPrefs.SetString(PrefKeys.NEXT_LEVEL, nextLevel);
    }

}
