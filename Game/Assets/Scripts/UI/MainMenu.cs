using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LoadLevel1()
    {
        SceneManager.LoadScene(Scenes.LEVEL_1);
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(Scenes.TUTORIAL);
    }

    public void LoadLevelsMenu()
    {
        SceneManager.LoadScene(Scenes.LEVELS_MENU);
    }

    public void LoadShopMenu()
    {
        SceneManager.LoadScene(Scenes.SHOP_MENU);
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene(Scenes.OPTIONS_MENU);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
