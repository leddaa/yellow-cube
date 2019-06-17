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

    // Upgrade Button 3 - Changes skin to "Hacker"
    public void Upgrade3()
    {
        PlayerPrefs.SetInt("index", 2);
    }

    // Upgrade Button 4 - Changes skin to "Matrix"
    public void Upgrade4()
    {
        PlayerPrefs.SetInt("index", 3);
    }

    // Upgrade Button 5 - Changes skin to "Burger"
    public void Upgrade5()
    {
        PlayerPrefs.SetInt("index", 4);
    }

    // Main Menu Button
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
