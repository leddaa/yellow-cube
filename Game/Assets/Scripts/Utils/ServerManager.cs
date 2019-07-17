using PubNubAPI;
using System;
using System.Collections.Generic;
using UnityEngine;

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
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        dataStore = GameObject.FindGameObjectWithTag("DataStore").GetComponent<DataStore>();

        PNConfiguration pnConfiguration = new PNConfiguration();
        pnConfiguration.PublishKey = "pub-c-909213ad-fe0b-4baf-84cb-11ce9fbd39d0";
        pnConfiguration.SubscribeKey = "sub-c-65f2ed5e-9391-11e9-9e92-263b5e4e5631";
        pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;

        pubnub = new PubNub(pnConfiguration);

        pubnub.SubscribeCallback += SubscribeCallbackHandler;

        pubnub.Subscribe()
            .Channels(new List<string>() {
                SUBSCRIBE_CHANNEL
            })
            .WithPresence()
            .Execute();
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

        Debug.Log("Fired data. " + "User: " + myFireObject.usr + ", Time: " + myFireObject.scr + ", Level: " + myFireObject.lvl);
    }

    public void Publish(MyClass myFireObject)
    {
        string fireobject = JsonUtility.ToJson(myFireObject);

        if(myFireObject.usr.Equals("") || myFireObject.lvl.Equals(""))
        {
            return;
        }

        pubnub.Publish()
            .Channel(PUBLISH_CHANNEL)
            .Message(fireobject)
            .Async((result, status) => {
                if (status.Error)
                {
                    Debug.Log("Error: " + status.Error);
                }
            });

        Debug.Log("Published data. " + "User: " + myFireObject.usr + ", Time: " + myFireObject.scr + ", Level: " + myFireObject.lvl);
    }

    private void SubscribeCallbackHandler(object sender, EventArgs e)
    {
        SubscribeEventEventArgs msgArgs = e as SubscribeEventEventArgs;

        if (msgArgs.MessageResult != null)
        {
            Dictionary<string, object> msg = msgArgs.MessageResult.Payload as Dictionary<string, object>;

            // Create and populate DataStoreObject with data from message
            DataStoreObject dataStoreObject = new DataStoreObject();

            foreach (string key in msg.Keys)
            {
                Dictionary<string, object> levelData = msg[key] as Dictionary<string, object>;
                string[] usernames = levelData["usernames"] as string[];
                int[] scores = levelData["scores"] as int[];

                Level level = new Level();
                level.usernames = usernames;
                level.scores = scores;

                dataStoreObject.levels.Add(key, level);
            }

            dataStore.SaveLeaderboards(dataStoreObject);
        }
    }

}