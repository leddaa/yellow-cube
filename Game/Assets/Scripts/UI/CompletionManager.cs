using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionManager : MonoBehaviour
{
    #region todo
    //private static readonly string HIGH_SCORE_KEY_PREFIX = "highscore_";

    //private void Awake()
    //{
    //    GameObject.FindGameObjectWithTag(Tags.COMPLETE_TIME).GetComponent<Text>().text = ((float)PlayerPrefs.GetInt(PrefKeys.COMPLETE_TIME) / CompleteManager.SECONDS_TO_MICROSECONDS).ToString("0.000", System.Globalization.CultureInfo.InvariantCulture) + " Sec";
    //    GameObject.FindGameObjectWithTag(Tags.COINS_TEXT).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS).ToString() + " Coins";
    //    GameObject.FindGameObjectWithTag(Tags.TOTAL_GEMS).GetComponent<TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag(Tags.DATA_STORE).GetComponent<DataStore>().GetInt(DatastoreKeys.TOTAL_YC_COINS, 0) + " YC Coins";
    //}

    //private void Start()
    //{
    //    CheckHighscore();
    //}
    #endregion

    public void LoadNextLevel()
    {
        Debug.Log("Load next");
        Debug.Log($"Load next level. Current index: {SceneManager.GetActiveScene().buildIndex}");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadCurrentLevel()
    {
        Debug.Log("Reload");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Debug.Log("Load main");
        SceneManager.LoadScene(Scenes.UI_MENU);
    }

    #region todo
    //private void CheckHighscore()
    //{
    //    string key = HIGH_SCORE_KEY_PREFIX + PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL);

    //    int timeSpent = PlayerPrefs.GetInt(PrefKeys.COMPLETE_TIME);

    //    Debug.Log("You spent " + (float)timeSpent / CompleteManager.SECONDS_TO_MICROSECONDS + " seconds (" + timeSpent + ")");

    //    float highscore = PlayerPrefs.GetInt(key);
    //    Debug.Log("Stored highscore pref: " + highscore / CompleteManager.SECONDS_TO_MICROSECONDS + " seconds (" + highscore + ")");

    //    if (highscore == 0 || timeSpent < highscore) // Highscore doesnt exist or new score is better
    //    {
    //        PlayerPrefs.SetInt(key, timeSpent);
    //        Debug.Log("New highscore set: " + timeSpent);
    //    }
    //}
    #endregion
}
