using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class StoreObject
{
    public Dictionary<string, object> dictionary = new Dictionary<string, object>();
}

public static class Store
{
    private static readonly string FILE_NAME = "store.yc";
    private static StoreObject storeObject;

    public static void Load() =>
        storeObject = GetStoreObject();

    private static void EnsureLoaded()
    {
        if (storeObject == null)
            Load();
    }

    public static void SetBool(string key, bool value)
    {
        EnsureLoaded();

        if (storeObject.dictionary.ContainsKey(key))
            storeObject.dictionary[key] = value;
        else
            storeObject.dictionary.Add(key, value);
    }

    public static bool GetBool(string key)
    {
        EnsureLoaded();

        if (!storeObject.dictionary.ContainsKey(key))
            throw new UnityException($"Boolean with key {key} doesn't exist.");

        return (bool)storeObject.dictionary[key];
    }

    public static void SetInt(string key, int value)
    {
        EnsureLoaded();

        if (storeObject.dictionary.ContainsKey(key))
            storeObject.dictionary[key] = value;
        else
            storeObject.dictionary.Add(key, value);
    }

    public static int GetInt(string key)
    {
        EnsureLoaded();

        if (storeObject == null)
            throw new UnityException($"Store object not initialized when setting key {key}.");

        if (!storeObject.dictionary.ContainsKey(key))
            throw new UnityException($"Integer with key {key} doesn't exist.");

        return (int)storeObject.dictionary[key];
    }

    public static int GetIntOrDefault(string key)
    {
        EnsureLoaded();

        if (storeObject == null)
            throw new UnityException($"Store object not initialized when setting key {key}.");

        if (!storeObject.dictionary.ContainsKey(key))
            return 0;

        return (int)storeObject.dictionary[key];
    }

    public static void SetHighscore(string mapName, int value)
    {
        var key = $"highscore_{mapName}";
        SetInt(key, value);

        Save();
    }

    public static int? GetHighcore(string mapName)
    {
        EnsureLoaded();
        var key = $"highscore_{mapName}";
        if (!storeObject.dictionary.ContainsKey(key))
            return null;

        return (int)storeObject.dictionary[key];
    }

    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream fs = GetFileStream(FILE_NAME))
            formatter.Serialize(fs, storeObject);
    }

    private static StoreObject GetStoreObject()
    {
        StoreObject storeObject;

        if (File.Exists(Application.persistentDataPath + FILE_NAME))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = File.Open(Application.persistentDataPath + FILE_NAME, FileMode.Open))
                storeObject = (StoreObject)formatter.Deserialize(fs);
                return storeObject;
        }
        else
        {
            Debug.Log("Data store file doesn't exist. Creating.");

            storeObject = new StoreObject();
            Save();

            return storeObject;
        }
    }

    private static FileStream GetFileStream(string fileName)
    {
        FileStream fs;

        if (File.Exists(Application.persistentDataPath + fileName))
            fs = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
        else
            fs = File.Open(Application.persistentDataPath + fileName, FileMode.Create);

        return fs;
    }
}