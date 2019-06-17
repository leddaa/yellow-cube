using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopSystem : MonoBehaviour
{

    // Upgrade Button 1 - Changes skin to "Yellow Cube"
    public void Upgrade1()  
    {
        PlayerPrefs.SetInt("index", 0);
    }

    // Upgrade Button 2 - Changes skin to "Black Medic"
    public void Upgrade2()
    {
        PlayerPrefs.SetInt("index", 1);
    }

    // Main Menu Button
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
