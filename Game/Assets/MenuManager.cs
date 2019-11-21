using UnityEngine;

// TODO: enum for screens

public class MenuManager : MonoBehaviour
{
    public int menuID;

    public GameObject[] menuPanels;

    private GameObject loginScreen;
    private GameObject mainMenuScreen;
    private GameObject optionsScreen;
    private GameObject shopScreen;
    private GameObject levelsScreen;
    private GameObject completeScreen;

    // Use this for initialization
    private void Start()
    {
        loginScreen = GameObject.FindGameObjectWithTag(Tags.CANVAS_LOGIN); // 0
        mainMenuScreen = GameObject.FindGameObjectWithTag(Tags.CANVAS_MAIN_MENU); // 1
        optionsScreen = GameObject.FindGameObjectWithTag(Tags.CANVAS_OPTIONS); // 2
        shopScreen = GameObject.FindGameObjectWithTag(Tags.CANVAS_SHOP); // 3
        levelsScreen = GameObject.FindGameObjectWithTag(Tags.CANVAS_LEVELS); // 4
        completeScreen = GameObject.FindGameObjectWithTag(Tags.CANVAS_LEVEL_COMPLETE); // 5
        
        if (PlayerPrefs.GetString(PrefKeys.USERNAME) != "")
        {
            menuID = 0;
        }
        else
        {
            menuID = 0;
        }

        SwitchToMenu(menuID);
    }

    public void SwitchToMenu(int menuID)
    {
        foreach (GameObject panel in menuPanels)
        {
            panel.gameObject.SetActive(false);
        }

        switch (menuID)
        {
            case 0:
                loginScreen.gameObject.SetActive(true);
                break;
            case 1:
                mainMenuScreen.gameObject.SetActive(true);
                break;
            case 2:
                optionsScreen.gameObject.SetActive(true);
                break;
            case 3:
                shopScreen.gameObject.SetActive(true);
                break;
            case 4:
                levelsScreen.gameObject.SetActive(true);
                break;
            case 5:
                completeScreen.gameObject.SetActive(true);
                break;
        }
    }
}
