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
        Debug.Log("DataStore awake");

        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        Debug.Log("initing datastores reference to servermanager");
        serverManager = GameObject.FindGameObjectWithTag("ServerManager").GetComponent<ServerManager>();
    }

    private void Start()
    {
        dataStoreObject = LoadLeaderboards();
    }

    public void bash()
    {
        Debug.Log("bash: Received data:");
        DataStoreObject loadData = LoadLeaderboards();

        foreach(string key in loadData.levels.Keys)
        {

            string jall = ""; //TODO remove
            foreach(string username in loadData.levels[key].usernames)
            {
                jall += username + ", ";
            }

            string skrall = ""; //TODO remove
            foreach (int score in loadData.levels[key].scores)
            {
                skrall += score + ", ";
            }

            Debug.Log("Key: " + key + " " + jall + " " + skrall);

        }
    }

    public Level GetLevel(string key)
    {
        Debug.Log("Active scene: " + key);

        if(!dataStoreObject.levels.ContainsKey(key))
        {
            Debug.Log("Key doesnt exist");
            MyClass myFireObject = new MyClass("Big bille", 999999999, SceneManager.GetActiveScene().name);
            serverManager.Fire(myFireObject);
        }
        else
        {
            Debug.Log("Key exists");
        }

        return dataStoreObject.levels[key];
    }

    public void SaveLeaderboards(DataStoreObject data)
    {
        Debug.Log("Save leaderboards()");

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = InitFile(LEADERBOARDS_FILE_NAME);

        formatter.Serialize(file, data);

        file.Close();

        Debug.Log("Save leaderboards success");
    }

    public void SaveLocalHighscores(LocalHighscores data)
    {
        Debug.Log("Save local highscores");

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = InitFile(LOCAL_HIGHSCORES_FILE_NAME);

        formatter.Serialize(file, data);

        file.Close();

        Debug.Log("Save local highscores success");
    }

    private DataStoreObject LoadLeaderboards()
    {
        Debug.Log("Load leaderboards()");

        if(File.Exists(Application.persistentDataPath + LEADERBOARDS_FILE_NAME))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + LEADERBOARDS_FILE_NAME, FileMode.Open);

            DataStoreObject data = (DataStoreObject)formatter.Deserialize(file);
            file.Close();

            return data;
        }
        else
        {
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
        
        if(localHighscores.highscores.ContainsKey(key))
        {
            return localHighscores.highscores[key];
        }

        return -1;
    }

    private FileStream InitFile(string fileName)
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
