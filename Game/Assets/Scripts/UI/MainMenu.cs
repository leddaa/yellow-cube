using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial Level");
    }

    public void LoadLevelsMenu()
    {
        SceneManager.LoadScene("LevelsMenu");
    }

    public void LoadShopMenu()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
