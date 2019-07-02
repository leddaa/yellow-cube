using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{

    void Start()
    {
        GameObject.Find(Tags.LEVEL_TEXT).GetComponent<Text>().text = SceneManager.GetActiveScene().name;

        Debug.Log("Leaderboard start with level " + SceneManager.GetActiveScene().name);

        Debug.Log("LeaderBoard: trying to find level from store. Trying to get with level " + SceneManager.GetActiveScene().name);
        Level level = GameObject.FindGameObjectWithTag(Tags.DATA_STORE).GetComponent<DataStore>().GetLevel(SceneManager.GetActiveScene().name);

        Debug.Log("Leaderboard printing stuff:");
        int usercounter = 1;
        foreach (string user in level.usernames)
        {
            string usernameobject = "User" + usercounter + "Text";
            GameObject.Find(usernameobject).GetComponent<Text>().text = usercounter.ToString() + ". " + user;
            usercounter++;
        }

        int scorecounter = 1;
        foreach (int score in level.scores)
        {
            string scoreobject = "Score" + scorecounter + "Text";
            GameObject.Find(scoreobject).GetComponent<Text>().text = "Time: " + score.ToString();
            scorecounter++;
        }
    }

}
