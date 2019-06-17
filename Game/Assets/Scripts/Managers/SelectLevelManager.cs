using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelManager : MonoBehaviour
{
    // Load Main Menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Load Level 1
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    // Load Level 2
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    // Load Level 3
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    // Load Level 4
    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
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
