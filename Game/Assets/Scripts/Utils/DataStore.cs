using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class DataStoreLocalObjects
{
    public Dictionary<string, object> localObjects = new Dictionary<string, object>();
}

public class DataStore : MonoBehaviour
{
    private static DataStore _instance = null;
    private static readonly string OBJECTS_FILE_NAME = "objects.yc";

    private static DataStoreLocalObjects dataStoreLocalObjects;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        dataStoreLocalObjects = LoadLocalObjects();
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

    public void SaveLocalObjects(DataStoreLocalObjects data)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = GetFile(OBJECTS_FILE_NAME);

        formatter.Serialize(file, data);

        file.Close();

        dataStoreLocalObjects = data;
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
}