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

    public void LoadLevels()
    {
        SceneManager.LoadScene("LevelsMenu");
    }
}
