using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public int menuID = 0;

    public GameObject[] menuPanels;
    private GameObject loginScreen;
    private GameObject mainMenuScreen;
    private GameObject optionsScreen;
    private GameObject shopScreen;
    private GameObject levelsScreen;
    private GameObject completeScreen;

    // Use this for initialization
    void Start()
    {
        loginScreen = GameObject.FindGameObjectWithTag("LoginScreen"); // 0
        mainMenuScreen = GameObject.FindGameObjectWithTag("MainMenuScreen"); // 1
        optionsScreen = GameObject.FindGameObjectWithTag("OptionsScreen"); // 2
        shopScreen = GameObject.FindGameObjectWithTag("ShopScreen"); // 3
        levelsScreen = GameObject.FindGameObjectWithTag("LevelsScreen"); // 4
        completeScreen = GameObject.FindGameObjectWithTag("CompleteScreen"); // 5

        //        int playerNum = PlayerInfo.playerID;
        //        Debug.Log (playerNum);
        switchToMenu(menuID);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void switchToMenu(int menuID)
    {

        foreach (GameObject panel in menuPanels)
        {
            //            panel.gameObject.renderer.enabled=false;
            panel.gameObject.SetActive(false);
            Debug.Log(panel.name + "SetActive = False");
        }

        switch (menuID)
        {
            case 0:
                loginScreen.gameObject.SetActive(true);
                Debug.Log("Case 0");
                break;
            case 1:
                mainMenuScreen.gameObject.SetActive(true);
                Debug.Log("Case 1");
                break;
            case 2:
                optionsScreen.gameObject.SetActive(true);
                Debug.Log("Case 2");
                break;
            case 3:
                shopScreen.gameObject.SetActive(true);
                Debug.Log("Case 3");
                break;
            case 4:
                levelsScreen.gameObject.SetActive(true);
                Debug.Log("Case 4");
                break;
            case 5:
                completeScreen.gameObject.SetActive(true);
                Debug.Log("Case 5");
                break;
        }
    }
}