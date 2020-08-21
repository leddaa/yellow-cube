using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public GameObject shopPanel;
    public GameObject levelsPanel;
    public GameObject levelCompletePanel;

    private void Start()
    {
        SetPanel("MainMenu");
    }

    public void SetPanel(string panel)
    {
        DisablePanels();

        switch (panel) 
        {
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

    public void QuitGame()
    {
        Application.Quit();
    }

    private void DisablePanels()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        shopPanel.SetActive(false);
        levelsPanel.SetActive(false);
        levelCompletePanel.SetActive(false);
    }
}
