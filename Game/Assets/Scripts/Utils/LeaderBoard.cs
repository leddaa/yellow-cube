using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{

    void Start()
    {
        GameObject.Find(Tags.LEVEL_TEXT).GetComponent<Text>().text = SceneManager.GetActiveScene().name;

        // when we get message from datastore
        {
            Dictionary<string, object> msg = mea.MessageResult.Payload as Dictionary<string, object>;

            Dictionary<string, object> levelData = msg[SceneManager.GetActiveScene().name] as Dictionary<string, object>;

            string[] users = levelData["usernames"] as string[];
            int[] scores = levelData["scores"] as int[];

            int usercounter = 1;
            foreach (string user in users)
            {
                string usernameobject = "User" + usercounter + "Text";
                GameObject.Find(usernameobject).GetComponent<Text>().text = usercounter.ToString() + ". " + user;
                usercounter++;
            }

            int scorecounter = 1;
            foreach (int score in scores)
            {
                string scoreobject = "Score" + scorecounter + "Text";
                GameObject.Find(scoreobject).GetComponent<Text>().text = "Time: " + score.ToString();
                scorecounter++;
            }
        }
    }

}
