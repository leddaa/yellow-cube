using UnityEngine;
using UnityEngine.SceneManagement;

public class TunnelDeathTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void OnTriggerStay(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            var playerSize = player.transform.localScale;

            Debug.Log(playerSize);

            if (playerSize.x != 0.5)
            {
                Debug.Log("Kill player");
                player.GetComponent<PlayerDeath>().Explode();
                Invoke("RestartLevel", 2f);


            }
        }
    }
}
