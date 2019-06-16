using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

}
