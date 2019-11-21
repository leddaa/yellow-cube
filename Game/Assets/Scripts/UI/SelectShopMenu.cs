using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectShopMenu : MonoBehaviour
{
    // Change scene to Skins Shop
    public void SkinsButton()
    {
        SceneManager.LoadScene(Scenes.SKINS_MENU);
    }

    // Change scene to Trails Shop
    public void TrailsButton()
    {
        SceneManager.LoadScene(Scenes.SKINS_MENU);
    }

    // Change scene to Music Shop
    public void MusicButton()
    {
        SceneManager.LoadScene(Scenes.SKINS_MENU);
    }

    // Change scene to Main Menu
    public void MainMenuButton()
    {
        SceneManager.LoadScene(Scenes.UI_MENU);
    }
}
