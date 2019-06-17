using UnityEngine;
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

}
