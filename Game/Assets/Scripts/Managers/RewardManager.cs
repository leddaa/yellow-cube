using UnityEngine;

public class RewardManager : MonoBehaviour
{

    private int totalCoins;
    private int threeStarsTime;
    private int twoStarsTime;
    private int oneStarsTime;
    private int oneStarsCoinsAmount;
    private int twoStarsCoinsAmount;
    private int threeStarsCoinsAmount;

    void Start()
    {
        // Coins
        totalCoins = PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS);
        oneStarsCoinsAmount = PlayerPrefs.GetInt(PrefKeys.oneStarCoinsAmount);
        twoStarsCoinsAmount = PlayerPrefs.GetInt(PrefKeys.twoStarCoinsAmount);
        threeStarsCoinsAmount = PlayerPrefs.GetInt(PrefKeys.threeStarCoinsAmount);

        // Stars
        threeStarsTime = PlayerPrefs.GetInt(PrefKeys.STAR_TIME_3);
        twoStarsTime = PlayerPrefs.GetInt(PrefKeys.STAR_TIME_2);
        oneStarsTime = PlayerPrefs.GetInt(PrefKeys.STAR_TIME_1);

        float completeTime = PlayerPrefs.GetInt(PrefKeys.COMPLETE_TIME);

        int caseSwitch = 1;

        if (threeStarsTime * CompleteManager.SECONDS_TO_MICROSECONDS> completeTime)
        {
            caseSwitch = 3;
        } else if
            (twoStarsTime * CompleteManager.SECONDS_TO_MICROSECONDS > completeTime)
        {
            caseSwitch = 2;
        } else if
            (oneStarsTime * CompleteManager.SECONDS_TO_MICROSECONDS > completeTime)
        {
            caseSwitch = 1;
        }

        switch (caseSwitch)
        {
            case 0:
                GameObject.FindGameObjectWithTag(Tags.STAR1).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.STAR2).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.STAR3).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.NEXT_LEVEL_BUTTON).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_COMPLETE_TITLE).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_FAILED_TITLE).SetActive(true);
                PlayerPrefs.SetInt(PrefKeys.STAR_TIME_0, 0);
                Debug.Log("Case 0");

                break;

            case 1:
                GameObject.FindGameObjectWithTag(Tags.STAR1).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR2).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.STAR3).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_FAILED_TITLE).SetActive(false);
                PlayerPrefs.SetInt(PrefKeys.STAR_TIME_0, 1);
                Debug.Log("Case 1");
                PlayerPrefs.SetInt(PrefKeys.TOTAL_COINS, totalCoins + oneStarsCoinsAmount);
                Debug.Log("Total Coins after: " + PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS));

                break;

            case 2:
                GameObject.FindGameObjectWithTag(Tags.STAR1).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR2).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR3).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_FAILED_TITLE).SetActive(false);
                PlayerPrefs.SetInt(PrefKeys.STAR_TIME_0, 1);
                Debug.Log("Case 2");
                PlayerPrefs.SetInt(PrefKeys.TOTAL_COINS, totalCoins + twoStarsCoinsAmount);
                Debug.Log("Total Coins after: " + PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS));

                break;

            case 3:
                GameObject.FindGameObjectWithTag(Tags.STAR1).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR2).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR3).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_FAILED_TITLE).SetActive(false);
                PlayerPrefs.SetInt(PrefKeys.STAR_TIME_0, 1);
                Debug.Log("Case 3");
                PlayerPrefs.SetInt(PrefKeys.TOTAL_COINS, totalCoins + threeStarsCoinsAmount);
                Debug.Log("Total Coins after: " + PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS));

                break;
        }
    }

}
