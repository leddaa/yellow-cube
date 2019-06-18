using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelMenu : MonoBehaviour
{
    // Load Main Menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }

    // Load Level 1
    public void LoadLevel1()
    {
        SceneManager.LoadScene(Scenes.LEVEL_1);
    }

    // Load Level 2
    public void LoadLevel2()
    {
        SceneManager.LoadScene(Scenes.LEVEL_2);
    }

    // Load Level 3
    public void LoadLevel3()
    {
        SceneManager.LoadScene(Scenes.LEVEL_3);
    }

    // Load Level 4
    public void LoadLevel4()
    {
        SceneManager.LoadScene(Scenes.LEVEL_4);
    }

    // Load Level 5 - Interactable set to false
    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }

    // Load Level 6
    public void LoadLevel6()
    {
        SceneManager.LoadScene("Level 6");
    }

}
