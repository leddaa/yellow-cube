using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(PrefKeys.PREVIOUS_LEVEL));
    }
}
