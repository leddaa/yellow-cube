using UnityEngine;
using UnityEngine.SceneManagement;

public class MapCompleteManager : MonoBehaviour
{

    private void Awake()
    {
        Debug.Log("menuload" + LevelManager.nextLevel);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(LevelManager.nextLevel);
        Debug.Log("OnClick" + LevelManager.nextLevel);
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
