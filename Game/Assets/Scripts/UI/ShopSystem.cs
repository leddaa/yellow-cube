using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopSystem : MonoBehaviour
{

    // Upgrade Button 1 - Changes skin to "Yellow Cube"
    public void Upgrade1()  
    {
        PlayerPrefs.SetInt(Keys.CURRENT_CHARACTER, 0);
    }

    // Upgrade Button 2 - Changes skin to "Black Medic"
    public void Upgrade2()
    {
        PlayerPrefs.SetInt(Keys.CURRENT_CHARACTER, 1);
    }

    // Upgrade Button 3 - Changes skin to "Hacker"
    public void Upgrade3()
    {
        PlayerPrefs.SetInt(Keys.CURRENT_CHARACTER, 2);
    }

    // Upgrade Button 4 - Changes skin to "Matrix"
    public void Upgrade4()
    {
        PlayerPrefs.SetInt(Keys.CURRENT_CHARACTER, 3);
    }

    // Upgrade Button 5 - Changes skin to "Burger"
    public void Upgrade5()
    {
        PlayerPrefs.SetInt(Keys.CURRENT_CHARACTER, 4);
    }

    // Upgrade Button 5 - Changes skin to "Scetchy Blue"
    public void Upgrade6()
    {
        PlayerPrefs.SetInt(Keys.CURRENT_CHARACTER, 5);
        Debug.Log("Model not set!");
    }

    // Main Menu Button
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }
}
