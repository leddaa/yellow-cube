using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class DataStoreObject
{
    public Dictionary<string, Level> levels = new Dictionary<string, Level>();
}

[Serializable]
public class Level
{
    public string[] usernames;
    public int[] scores;
}

[Serializable]
public class LocalHighscores
{
    public Dictionary<string, int> highscores = new Dictionary<string, int>();
}

// TODO ? class

public class DataStore : MonoBehaviour
{

    private static DataStore Instance = null;
    private static string LEADERBOARDS_FILE_NAME = "leaderboards.yc";
    private static string LOCAL_HIGHSCORES_FILE_NAME = "local_highscores.yc";

    private ServerManager serverManager;

    private static DataStoreObject dataStoreObject;

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

        serverManager = GameObject.FindGameObjectWithTag("ServerManager").GetComponent<ServerManager>();

        dataStoreObject = LoadLeaderboards();
    }

    private void Start()
    {

    }

    public void PrintData()
    {
        DataStoreObject loadData = LoadLeaderboards();

        foreach (string key in loadData.levels.Keys)
        {

            string usernames = "";
            foreach (string username in loadData.levels[key].usernames)
            {
                usernames += username + ", ";
            }

            string scores = "";
            foreach (int score in loadData.levels[key].scores)
            {
                scores += score + ", ";
            }

            Debug.Log("Key: " + key + " " + usernames + " " + scores);
        }
    }

    public Level GetLevel(string key)
    {
        if (!dataStoreObject.levels.ContainsKey(key)) // Key doesn't exist
        {
            Debug.Log("Key doesn't exist. Creating dummy data for level");
            MyClass myFireObject = new MyClass("Dummy", 100000000, SceneManager.GetActiveScene().name);

            Level level = new Level();
            level.usernames = new string[] { "local_dummy", "local_dummy", "local_dummy", "local_dummy", "local_dummy" };
            level.scores = new int[] { 100000000, 100000000, 100000000, 100000000, 100000000 };

            dataStoreObject.levels.Add(key, level);
        }

        string usernames = "";
        string scores = "";

        foreach (string usr in dataStoreObject.levels[key].usernames)
        {
            usernames += " " + usr;
        }
        foreach (int scr in dataStoreObject.levels[key].scores)
        {
            scores += " " + scr;
        }

        Debug.Log("GetLevel Usernames: " + usernames);
        Debug.Log("GetLevel Scores: " + scores);

        return dataStoreObject.levels[key];
    }


    public void SaveLeaderboards(DataStoreObject data)
    {
        Debug.Log("Save leaderboards()");

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = GetFile(LEADERBOARDS_FILE_NAME);

        formatter.Serialize(file, data);

        file.Close();

        dataStoreObject = data;

        Debug.Log("Save leaderboards success");
    }

    public void SaveLocalHighscores(LocalHighscores data)
    {
        Debug.Log("Save local highscores");

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = GetFile(LOCAL_HIGHSCORES_FILE_NAME);

        formatter.Serialize(file, data);

        file.Close();

        Debug.Log("Save local highscores success");
    }

    private DataStoreObject LoadLeaderboards()
    {
        Debug.Log("Load leaderboards()");

        if (File.Exists(Application.persistentDataPath + LEADERBOARDS_FILE_NAME))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + LEADERBOARDS_FILE_NAME, FileMode.Open);

            DataStoreObject data = (DataStoreObject)formatter.Deserialize(file);
            file.Close();

            return data;
        }
        else
        {
            Debug.Log("Error: DataStoreObject is null");
            return null;
        }
    }

    private LocalHighscores LoadLocalHighscores()
    {
        Debug.Log("Load local highscores");

        if (File.Exists(Application.persistentDataPath + LOCAL_HIGHSCORES_FILE_NAME))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + LOCAL_HIGHSCORES_FILE_NAME, FileMode.Open);

            LocalHighscores data = (LocalHighscores)formatter.Deserialize(file);
            file.Close();

            return data;
        }
        else
        {
            return null;
        }
    }

    public int GetLocalHighscore(string key)
    {
        LocalHighscores localHighscores = LoadLocalHighscores();

        if (localHighscores.highscores.ContainsKey(key))
        {
            return localHighscores.highscores[key];
        }

        return -1;
    }

    private FileStream GetFile(string fileName)
    {
        FileStream file;

        if (File.Exists(Application.persistentDataPath + fileName))
        {
            file = File.Open(Application.persistentDataPath + fileName, FileMode.Open); // Open existing file
            Debug.Log("Opening existing file");
        }
        else
        {
            file = File.Open(Application.persistentDataPath + fileName, FileMode.Create); // Create new file
            Debug.Log("Oreated new file");
        }

        return file;
    }

}