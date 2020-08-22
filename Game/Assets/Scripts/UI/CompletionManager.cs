using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI bestTimeText;
    public TextMeshProUGUI timeText;

    private void Awake()
    {
        levelText.text = SceneManager.GetActiveScene().name;
        timeText.text = $"{((float)Store.GetInt(StoreKeys.TimeSpent) / 1000000).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)} s";

        if (Store.GetBool(StoreKeys.IsNewHighscore))
        {
            bestTimeText.text = "New best time!";
        }
        else
        {
            bestTimeText.text = $"Best time: {((float)Store.GetHighcore(SceneManager.GetActiveScene().name) / 1000000).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}s";
        }
    }

    public void LoadNextLevel()
    {
        Store.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadCurrentLevel()
    {
        Store.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Store.Save();
        SceneManager.LoadScene(Scenes.UI_MENU);
    }
}
