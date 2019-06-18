using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("next_level"));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("CompleteTime").GetComponent<Text>().text = PlayerPrefs.GetFloat("CompleteTime").ToString(".0") + " Sec";
        GameObject.FindGameObjectWithTag("TotalFails").GetComponent<Text>().text = PlayerPrefs.GetInt(CompleteManager.TOTAL_FAIL_COUNTER_KEY).ToString() + " fails";
    }
}
