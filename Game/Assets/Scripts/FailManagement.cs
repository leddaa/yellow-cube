using UnityEngine;
using UnityEngine.UI;

public class FailManagement : MonoBehaviour
{

    static public int failCounter;
    private Text failText;
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        failText = GameObject.FindGameObjectWithTag("FailText").GetComponent<Text>();
    }

    void Update()
    {
        failText.text = failCounter.ToString() + " fails";

        if (playerTransform.position.y < -10)
        {
            failCounter++;
        }
    }

}
