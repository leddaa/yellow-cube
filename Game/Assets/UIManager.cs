using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public GameObject shopPanel;
    public GameObject levelsPanel;
    public GameObject levelCompletePanel;

    public void SetPanel(string panel)
    {
        DisablePanels();

        switch (panel) 
        {
            case "Login":
                loginPanel.SetActive(true);
                break;
            case "MainMenu":
                mainMenuPanel.SetActive(true);
                break;
            case "Options":
                optionsPanel.SetActive(true);
                break;
            case "Shop":
                shopPanel.SetActive(true);
                break;
            case "Levels":
                levelsPanel.SetActive(true);
                break;
            case "LevelComplete":
                levelCompletePanel.SetActive(true);
                break;
        }
    }

    private void Start()
    {
        SetPanel("Login");
    }

    private void DisablePanels()
    {
        loginPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        shopPanel.SetActive(false);
        levelsPanel.SetActive(false);
        levelCompletePanel.SetActive(false);
    }
}
