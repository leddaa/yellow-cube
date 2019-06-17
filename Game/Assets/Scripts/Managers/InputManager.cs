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

        // Mute function
        if (Input.GetKeyDown("p"))
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().ToggleMusic();
        }
    }

    private void Update()
    {
        
    }
}
