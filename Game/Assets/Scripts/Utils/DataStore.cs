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
public class DataStoreLocalObjects
{
    public Dictionary<string, object> localObjects = new Dictionary<string, object>();
}

public class DataStore : MonoBehaviour
{

    private static DataStore Instance = null;
    private static readonly string LEADERBOARDS_FILE_NAME = "leaderboards.yc";
    private static readonly string OBJECTS_FILE_NAME = "objects.yc";

    private static DataStoreObject dataStoreObject;

    private static DataStoreLocalObjects dataStoreLocalObjects;

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

        dataStoreObject = LoadLeaderboards();

        dataStoreLocalObjects = LoadLocalObjects();
    }

    public Level GetLevel(string key)
    {
        if (!dataStoreObject.levels.ContainsKey(key)) // Key doesn't exist
        {
            Level level = new Level();
            level.usernames = new string[] { "local_dummy", "local_dummy", "local_dummy", "local_dummy", "local_dummy" };
            level.scores = new int[] { 100000000, 100000000, 100000000, 100000000, 100000000 };

            dataStoreObject.levels.Add(key, level);
        }

        PrintLevel(key);

        return dataStoreObject.levels[key];
    }

    public void SetBool(string key, bool value)
    {
        if(dataStoreLocalObjects.localObjects.ContainsKey(key))
        {
            dataStoreLocalObjects.localObjects[key] = value;
        } else
        {
            dataStoreLocalObjects.localObjects.Add(key, value);
        }

        SaveLocalObjects(dataStoreLocalObjects);
    }

    public bool GetBool(string key)
    {
        if(!dataStoreLocalObjects.localObjects.ContainsKey(key))
        {
            throw new UnityException("Bool with key " + key + " doesn't exist");
        }

        return (bool)dataStoreLocalObjects.localObjects[key];
    }

    public void SetInt(string key, int value)
    {
        if (dataStoreLocalObjects.localObjects.ContainsKey(key))
        {
            dataStoreLocalObjects.localObjects[key] = value;
        }
        else
        {
            dataStoreLocalObjects.localObjects.Add(key, value);
        }

        SaveLocalObjects(dataStoreLocalObjects);
    }

    public int GetInt(string key)
    {
        if (!dataStoreLocalObjects.localObjects.ContainsKey(key))
        {
            throw new UnityException("Int with key " + key + " doesn't exist");
        }

        return (int)dataStoreLocalObjects.localObjects[key];
    }

    public int GetInt(string key, int defaulValue)
    {
        if (!dataStoreLocalObjects.localObjects.ContainsKey(key))
        {
            return defaulValue;
        }

        return (int)dataStoreLocalObjects.localObjects[key];
    }
    public void SaveLeaderboards(DataStoreObject data)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = GetFile(LEADERBOARDS_FILE_NAME);

        formatter.Serialize(file, data);

        file.Close();

        dataStoreObject = data;
    }

    public void SaveLocalObjects(DataStoreLocalObjects data)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = GetFile(OBJECTS_FILE_NAME);

        formatter.Serialize(file, data);

        file.Close();

        dataStoreLocalObjects = data;
    }

    private DataStoreObject LoadLeaderboards()
    {
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

    private DataStoreLocalObjects LoadLocalObjects()
    {
        if (File.Exists(Application.persistentDataPath + OBJECTS_FILE_NAME))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + OBJECTS_FILE_NAME, FileMode.Open);

            DataStoreLocalObjects data = (DataStoreLocalObjects)formatter.Deserialize(file);
            file.Close();

            return data;
        }
        else
        {
            Debug.Log("Error: DataStoreLocalObjects file doesnt exist. creating");

            DataStoreLocalObjects obj = new DataStoreLocalObjects();

            SaveLocalObjects(obj);

            return obj;
        }
    }

    private FileStream GetFile(string fileName)
    {
        FileStream file;

        if (File.Exists(Application.persistentDataPath + fileName))
        {
            file = File.Open(Application.persistentDataPath + fileName, FileMode.Open); // Open existing file
        }
        else
        {
            file = File.Open(Application.persistentDataPath + fileName, FileMode.Create); // Create new file
        }

        return file;
    }

    public void PrintLevels()
    {
        foreach (string key in dataStoreObject.levels.Keys)
        {
            PrintLevel(key);
        }
    }

    private void PrintLevel(string key)
    {
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

        Debug.Log("Level Usernames: " + usernames);
        Debug.Log("Level Scores: " + scores);
    }

}