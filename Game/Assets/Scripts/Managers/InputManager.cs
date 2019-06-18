using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

    private bool musicisplaying;
    void FixedUpdate()
    {

        // Exit to Main menu
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }

        // Toggle music on/off
        if (Input.GetKeyDown("p"))
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().ToggleMusic();
        }
    }

}
