using System.Collections.Generic;
using UnityEngine;
using PubNubAPI;
using UnityEngine.UI;

public class MyClass
{
    public string usr;
    public string scr;
    public string lvl;
}

public class LeaderBoard : MonoBehaviour
{
    public static PubNub pubnub;
    public Text Line1;
    public Text Line2;
    public Text Line3;
    public Text Line4;
    public Text Line5;
    public Text Score1;
    public Text Score2;
    public Text Score3;
    public Text Score4;
    public Text Score5;

    public string level = "";

    public Button SubmitButton;
    public InputField FieldUsername;
    public InputField FieldScore;
    public InputField FieldLevel;
    //public Object[] tiles = {}
    // Use this for initialization
    void Start()
    {
        GameObject.Find("LevelText").GetComponent<Text>().text = "Level" + level;

        Button btn = SubmitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        // Use this for initialization
        PNConfiguration pnConfiguration = new PNConfiguration();
        pnConfiguration.PublishKey = "pub-c-909213ad-fe0b-4baf-84cb-11ce9fbd39d0"; // "pub -c-700d6386-17c7-4439-8d18-3472814914de";
        pnConfiguration.SubscribeKey = "sub-c-65f2ed5e-9391-11e9-9e92-263b5e4e5631"; // "sub -c-523850fa-5865-11e8-9796-063929a21258";

        pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
        pnConfiguration.UUID = "Torkila"; // Random.Range (0f, 999999f).ToString ();

        pubnub = new PubNub(pnConfiguration);

        MyClass myFireObject = new MyClass();
        myFireObject.usr = "lars";
        myFireObject.scr = "46";
        myFireObject.lvl = "1";

        string fireobject = JsonUtility.ToJson(myFireObject);
        pubnub.Fire()
            .Channel("my_channel")
            .Message(fireobject)
            .Async((result, status) => {
                if (status.Error)
                {
                    Debug.Log("Message received: error");
                }

                Debug.Log("result: " + result);
            });

        pubnub.SusbcribeCallback += (sender, e) => {
            SusbcribeEventEventArgs mea = e as SusbcribeEventEventArgs;

            if (mea.MessageResult != null)
            {
                Dictionary<string, object> msg = mea.MessageResult.Payload as Dictionary<string, object>;

                Dictionary<string, object> ty = msg["level" + level] as Dictionary<string, object>;

                string[] users = ty["usernames"] as string[];
                int[] scores = ty["scores"] as int[];

                Debug.Log("hello");

                for (int i = 0; i < 5; i++)
                {
                    Debug.Log("hook - " + users[i] + ": " + scores[i]);
                }

                int usercounter = 1;

                foreach (string user in users)
                {
                    string usernameobject = "Line" + usercounter;
                    GameObject.Find(usernameobject).GetComponent<Text>().text = usercounter.ToString() + ". " + user;
                    usercounter++;
                }

                int scorecounter = 1;

                foreach (int score in scores)
                {
                    string scoreobject = "Score" + scorecounter;
                    GameObject.Find(scoreobject).GetComponent<Text>().text = "Score: " + score.ToString();
                    scorecounter++;
                }

                /*
				int usernamevar = 1;
				foreach (string username in strArr)
				{
					string usernameobject = "Line" + usernamevar;
					GameObject.Find(usernameobject).GetComponent<Text>().text = usernamevar.ToString() + ". " + username.ToString();
					usernamevar++;
					Debug.Log(username);
				}

				int scorevar = 1;
				foreach (string score in strScores)
				{
					string scoreobject = "Score" + scorevar;
					GameObject.Find(scoreobject).GetComponent<Text>().text = "Score: " + score.ToString();
					scorevar++;
                    Debug.Log(score);

				}
                */
            }
            else
            {
                Debug.Log("nop");
            }
            if (mea.PresenceEventResult != null)
            {
                Debug.Log("In Example, SusbcribeCallback in presence" + mea.PresenceEventResult.Channel + mea.PresenceEventResult.Occupancy + mea.PresenceEventResult.Event);
            }
        };
        pubnub.Subscribe()
            .Channels(new List<string>() {
                "my_channel2"
            })
            .WithPresence()
            .Execute();
    }

    void TaskOnClick()
    {
        Debug.Log("click");

        var usernametext = FieldUsername.text;// this would be set somewhere else in the code
        var scoretext = FieldScore.text;

        MyClass myObject = new MyClass();
        myObject.usr = FieldUsername.text;
        myObject.scr = FieldScore.text;
        myObject.lvl = FieldLevel.text;
        level = FieldLevel.text;
        GameObject.Find("LevelText").GetComponent<Text>().text = "Level " + level;

        string json = JsonUtility.ToJson(myObject);

        pubnub.Publish()
            .Channel("my_channel")
            .Message(json)
            .Async((result, status) => {
                if (!status.Error)
                {
                    Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
                }
                else
                {
                    Debug.Log(status.Error);
                    Debug.Log(status.ErrorData.Info);
                }
            });
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button!");
    }

}
