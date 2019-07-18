using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelCompleteMenu : MonoBehaviour
{

    private static readonly string HIGH_SCORE_KEY_PREFIX = "highscore_";

    private void Awake()
    {
        // Set complete time text
        GameObject.FindGameObjectWithTag(Tags.COMPLETE_TIME).GetComponent<Text>().text = ((float)PlayerPrefs.GetInt(PrefKeys.COMPLETE_TIME) / CompleteManager.SECONDS_TO_MICROSECONDS).ToString("0.000", System.Globalization.CultureInfo.InvariantCulture) + " Sec";
        //GameObject.FindGameObjectWithTag(Tags.COINS_TEXT).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS).ToString() + " Coins";
    }

    private void Start()
    {
        CheckHighscore();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(PrefKeys.NEXT_LEVEL));
    }

    public void LoadPreviousLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }

    public void LoadShop()
    {
        SceneManager.LoadScene(Scenes.SHOP_MENU);
    }

    private void CheckHighscore()
    {
        string key = HIGH_SCORE_KEY_PREFIX + PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL);

        int timeSpent = PlayerPrefs.GetInt(PrefKeys.COMPLETE_TIME);

        Debug.Log("You spent " + (float)timeSpent / CompleteManager.SECONDS_TO_MICROSECONDS + " seconds (" + timeSpent + ")");

        float highscore = PlayerPrefs.GetInt(key);
        Debug.Log("Stored highscore pref: " + highscore / CompleteManager.SECONDS_TO_MICROSECONDS + " seconds (" + highscore + ")");

        if (highscore == 0 || timeSpent < highscore) // Highscore doesnt exist or new score is better
        {
            PlayerPrefs.SetInt(key, timeSpent);
            Debug.Log("New highscore set: " + timeSpent);

            MyClass myFireObject = new MyClass(PlayerPrefs.GetString(PrefKeys.USERNAME), timeSpent, PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL));
            GameObject.FindGameObjectWithTag(Tags.SERVER_MANAGER).GetComponent<ServerManager>().Publish(myFireObject);
        }
    }

}
