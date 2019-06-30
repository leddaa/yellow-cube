using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(Keys.NEXT_LEVEL));
    }

    public void LoadPreviousLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(Keys.PREVIOUS_LEVEL));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }

    public void LoadShop()
    {
        SceneManager.LoadScene(Scenes.SHOP_MENU);
    }

    private void Awake()
    {
        // Level complete TIME
        GameObject.FindGameObjectWithTag(Tags.COMPLETE_TIME).GetComponent<Text>().text = 
            (PlayerPrefs.GetFloat(Keys.COMPLETE_TIME) / CompleteManager.SECONDS_TO_MICROSECONDS).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " sec"; ;

        // Level complete FAILS
        GameObject.FindGameObjectWithTag(Tags.TOTAL_FAILS).GetComponent<Text>().text = PlayerPrefs.GetInt(Keys.TOTAL_FAIL_COUNTER).ToString() + " fails";
    }
}
