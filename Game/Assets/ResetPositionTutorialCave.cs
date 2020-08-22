using UnityEngine;

public class ResetPositionTutorialCave : MonoBehaviour
{
    public Vector3 playerPosition;

    private void OnTriggerStay(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            var playerSize = player.transform.localScale;
            Debug.Log(playerSize);

            if (playerSize.x != 0.5)
            {
                Debug.Log("Reset player position");
                player.transform.localPosition = playerPosition;
                
            }
        }
    }
}
