using UnityEngine;
using PubNubAPI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

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

public class ServerManager : MonoBehaviour
{

    private static ServerManager Instance = null;

    private readonly static string PUBLISH_CHANNEL = "my_channel";
    private readonly static string SUBSCRIBE_CHANNEL = "my_channel2";

    public static PubNub pubnub;
    private DataStore dataStore;

    private void Awake()
    {
        Debug.Log("ServerManager Awake");

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        dataStore = GameObject.FindGameObjectWithTag("DataStore").GetComponent<DataStore>();
    }

    void Start()
    {
        Debug.Log("Server manager start");

        // Configuration
        PNConfiguration pnConfiguration = new PNConfiguration();
        pnConfiguration.PublishKey = "pub-c-909213ad-fe0b-4baf-84cb-11ce9fbd39d0";
        pnConfiguration.SubscribeKey = "sub-c-65f2ed5e-9391-11e9-9e92-263b5e4e5631";
        pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;

        pubnub = new PubNub(pnConfiguration);

        pubnub.SubscribeCallback += (sender, e) => {
            SubscribeEventEventArgs msgArgs = e as SubscribeEventEventArgs;
            Debug.Log("servmng subcallback");

            if (msgArgs.MessageResult != null)
            {
                Dictionary<string, object> msg = msgArgs.MessageResult.Payload as Dictionary<string, object>;


                //Dictionary<string, object> levelData = msg[SceneManager.GetActiveScene().name] as Dictionary<string, object>;

                // Create and populate DataStoreObject with data from message
                DataStoreObject dataStoreObject = new DataStoreObject();

                foreach(string key in msg.Keys)
                {
                    Dictionary<string, object> levelData = msg[key] as Dictionary<string, object>;
                    string[] usernames = levelData["usernames"] as string[];
                    int[] scores = levelData["scores"] as int[];

                    Level level = new Level();
                    level.usernames = usernames;
                    level.scores = scores;

                    dataStoreObject.levels.Add(key, level);
                }

                Debug.Log("Callback doing save");
                dataStore.SaveLeaderboards(dataStoreObject);

                dataStore.bash();
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

    public void Fire(MyClass myFireObject)
    {
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

        Debug.Log("finished fire()");
    }

    public void hei()
    {
        Debug.Log("hei");
        PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_LEVEL_1, 100000000);
        PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_LEVEL_2, 100000000);
        PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_LEVEL_3, 100000000);
        PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_LEVEL_4, 100000000);
        PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_LEVEL_5, 100000000);
        PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_LEVEL_6, 100000000);
        PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_LEVEL_7, 100000000);
        PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_LEVEL_8, 100000000);
        PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_LEVEL_9, 100000000);
        PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_LEVEL_10, 100000000);
    }

}
