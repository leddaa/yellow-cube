using UnityEngine;

public class LevelData : MonoBehaviour
{
    [Header("Stars Time")]
    public int oneStarsTime; 
    public int twoStarsTime;
    public int threeStarsTime;

    [Header("Coins")]
    public int oneStarsCoinsAmount;
    public int twoStarsCoinsAmount;
    public int threeStarsCoinsAmount;

    [Header("Next Level")]
    public string nextLevel;

    private void Start()
    {
        PlayerPrefs.SetString(PrefKeys.NEXT_LEVEL, nextLevel);
    }
}
