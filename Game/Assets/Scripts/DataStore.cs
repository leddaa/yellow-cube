using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

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

public class DataStore : MonoBehaviour
{

    private static string FILE_NAME = "local_data_test.yc";

    public void bash()
    {
        Debug.Log("bash");
        DataStoreObject loadData = Load();

        foreach(string key in loadData.levels.Keys)
        {
            Debug.Log("Key: " + key);

            foreach(string username in loadData.levels[key].usernames)
            {
                Debug.Log("Username: " + username);
            }

            foreach (int score in loadData.levels[key].scores)
            {
                Debug.Log("Score: " + score);
            }

        }
    }

    public void Save(DataStoreObject data)
    {
        Debug.Log("Save()");

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = InitFile();

        formatter.Serialize(file, data);

        file.Close();

        Debug.Log("Save success");
    }

    private DataStoreObject Load()
    {
        Debug.Log("Load()");

        if(File.Exists(Application.persistentDataPath + FILE_NAME))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + FILE_NAME, FileMode.Open);

            DataStoreObject data = (DataStoreObject)formatter.Deserialize(file);
            file.Close();

            return data;
        }
        else
        {
            return null;
        }
    }

    private FileStream InitFile()
    {
        FileStream file;

        if (File.Exists(Application.persistentDataPath + FILE_NAME))
        {
            file = File.Open(Application.persistentDataPath + FILE_NAME, FileMode.Open); // open existing file
            Debug.Log("opening existing file");
        }
        else
        {
            file = File.Open(Application.persistentDataPath + FILE_NAME, FileMode.Create); // create new file
            Debug.Log("created new file");
        }

        return file;
    }

}
