using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(PrefKeys.NEXT_LEVEL));
    }

    public void LoadPreviousLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL));
        Debug.Log(PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL));
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
        // Level complete time
        GameObject.FindGameObjectWithTag(Tags.COMPLETE_TIME).GetComponent<Text>().text = (PlayerPrefs.GetFloat(PrefKeys.COMPLETE_TIME) / CompleteManager.SECONDS_TO_MICROSECONDS).ToString(".0", System.Globalization.CultureInfo.InvariantCulture) + " Sec";
    }

}
