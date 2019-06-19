﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(Keys.NEXT_LEVEL));
    }

    public void LoadPreviousLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(Keys.PREVIOUS_LEVEL));
        Debug.Log(PlayerPrefs.GetString(Keys.PREVIOUS_LEVEL));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }

    public void LoadShop()
    {
        SceneManager.LoadScene(Scenes.SHOP_MENU);
        Debug.Log("Shop Loaded");
    }

    private void Awake()
    {
        GameObject.FindGameObjectWithTag(Tags.COMPLETE_TIME).GetComponent<Text>().text = PlayerPrefs.GetFloat(Keys.COMPLETE_TIME).ToString(".0") + " Sec";
        GameObject.FindGameObjectWithTag(Tags.TOTAL_FAILS).GetComponent<Text>().text = PlayerPrefs.GetInt(Keys.TOTAL_FAIL_COUNTER).ToString() + " fails";
    }
}
