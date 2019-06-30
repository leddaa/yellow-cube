using System.Collections.Generic;
using UnityEngine;
using PubNubAPI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyClass
{

    public string usr;
    public int scr;
    public string lvl;

    public MyClass(string username, int score, string level)
    {
        this.usr = username;
        this.scr = score;
        this.lvl = level;
    }

}

public class LeaderBoard : MonoBehaviour
{
    private static string PUBLISH_CHANNEL = "my_channel";
    private static string SUBSCRIBE_CHANNEL = "my_channel2";

    public static PubNub pubnub;

    void Start()
    {
        GameObject.Find(Tags.LEVEL_TEXT).GetComponent<Text>().text = SceneManager.GetActiveScene().name;

        // configuration
        PNConfiguration pnConfiguration = new PNConfiguration();
        pnConfiguration.PublishKey = "pub-c-909213ad-fe0b-4baf-84cb-11ce9fbd39d0";
        pnConfiguration.SubscribeKey = "sub-c-65f2ed5e-9391-11e9-9e92-263b5e4e5631";
        pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;

        pubnub = new PubNub(pnConfiguration);

        // create object to send
        MyClass myFireObject = new MyClass("Fake", 1000000000, SceneManager.GetActiveScene().name);

        string fireobject = JsonUtility.ToJson(myFireObject);
        pubnub.Fire()
            .Channel(PUBLISH_CHANNEL)
            .Message(fireobject)
            .Async((result, status) => {
                if (status.Error)
                {
                    Debug.Log("Error: " + status.Error);
                }
            });

        pubnub.SubscribeCallback += (sender, e) => {
            SubscribeEventEventArgs mea = e as SubscribeEventEventArgs;

            if (mea.MessageResult != null)
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
        };

        pubnub.Subscribe()
            .Channels(new List<string>() {
                SUBSCRIBE_CHANNEL
            })
            .WithPresence()
            .Execute();
    }

    public void PublishScore(string username, int score, string level)
    {
        string message = JsonUtility.ToJson(new MyClass(username, score, level));

        pubnub.Publish()
            .Channel(PUBLISH_CHANNEL)
            .Message(message)
            .Async((result, status) => {
                if (status.Error)
                {
                    Debug.Log(status.Error);
                    Debug.Log(status.ErrorData.Info);
                }
            });

        Debug.Log("Published data. " + "User: " + username + ", Time: " + score + ", Level: " + level);
    }

}
