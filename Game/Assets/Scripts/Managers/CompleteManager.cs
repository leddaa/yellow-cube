﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteManager : MonoBehaviour
{

    private AudioManager audioManager;
    

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>();
        
    }

    public void CompleteMap()
    {

        PlayerPrefs.SetString(Keys.PREVIOUS_LEVEL, SceneManager.GetActiveScene().name);
        

        PlayerPrefs.SetFloat(Keys.COMPLETE_TIME, GameObject.FindGameObjectWithTag(Tags.TIME_TRACKER).GetComponent<TimeTracker>().timeSpent);
        GameObject.FindGameObjectWithTag(Tags.TIME_TRACKER).GetComponent<TimeTracker>().mapCompleted = true;

        PlayerPrefs.SetInt(Keys.TOTAL_FAIL_COUNTER, PlayerPrefs.GetInt(Keys.FAIL_COUNTER));
        PlayerPrefs.SetInt(Keys.FAIL_COUNTER, 0);

        audioManager.Play(Audio.COMPLETE_SOUND);
        
        SceneManager.LoadScene(Scenes.MAP_COMPLETE);

        // Get stars time

        // Get time for level failed
        PlayerPrefs.SetInt(Keys.STAR_TIME_0, 0);
        Debug.Log("Star_Time_0 " + PlayerPrefs.GetString(Keys.STAR_TIME_0));

        // Get time for Star 1
        PlayerPrefs.SetInt(Keys.STAR_TIME_1, GameObject.FindGameObjectWithTag(Tags.STARSTIME).GetComponent<StarsTime>().oneStars);
        Debug.Log("Star_Time_1 " + PlayerPrefs.GetString(Keys.STAR_TIME_1));

        // Get time for Star 2
        PlayerPrefs.SetInt(Keys.STAR_TIME_2, GameObject.FindGameObjectWithTag(Tags.STARSTIME).GetComponent<StarsTime>().twoStars);
        Debug.Log("Star_Time_2 " + PlayerPrefs.GetString(Keys.STAR_TIME_2));

        // Get time for Star 3
        PlayerPrefs.SetInt(Keys.STAR_TIME_3, GameObject.FindGameObjectWithTag(Tags.STARSTIME).GetComponent<StarsTime>().threeStars);
        Debug.Log("Star_Time_3 " + PlayerPrefs.GetString(Keys.STAR_TIME_3));
    }

}
