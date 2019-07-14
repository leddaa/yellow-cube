﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenuManager : MonoBehaviour
{

    private void Disable(string button)
    {
        GameObject.FindGameObjectWithTag(button).GetComponent<Image>().color = new Color32(200, 200, 200, 100);
        GameObject.FindGameObjectWithTag(button).GetComponent<Button>().interactable = false;
    }


    void Start()
    {
        Debug.Log("Level 1 unlocked: " + PlayerPrefs.GetInt(PrefKeys.LEVEL_1_UNLOCKED));
        Debug.Log("Level 2 unlocked: " + PlayerPrefs.GetInt(PrefKeys.LEVEL_2_UNLOCKED));
        Debug.Log("Level 3 unlocked: " + PlayerPrefs.GetInt(PrefKeys.LEVEL_3_UNLOCKED));
        Debug.Log("Level 4 unlocked: " + PlayerPrefs.GetInt(PrefKeys.LEVEL_4_UNLOCKED));
        Debug.Log("Level 5 unlocked: " + PlayerPrefs.GetInt(PrefKeys.LEVEL_5_UNLOCKED));
        Debug.Log("Level 6 unlocked: " + PlayerPrefs.GetInt(PrefKeys.LEVEL_6_UNLOCKED));




        // Level 1 is always unlocked
        // Level 2 unlocked/locked
        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_2_UNLOCKED) == 0)
        {
            Disable(Tags.BUTTON_LEVEL_2);
        }

        // Level 3 unlocked/locked
        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_3_UNLOCKED) == 0)
        {
            Disable(Tags.BUTTON_LEVEL_3);
        }

        // Level 4 unlocked/locked
        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_4_UNLOCKED) == 0)
        {
            Disable(Tags.BUTTON_LEVEL_4);
        }

        // Level 5 unlocked/locked
        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_5_UNLOCKED) == 0)
        {
            Disable(Tags.BUTTON_LEVEL_5);
        }

        // Level 6 unlocked/locked
        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_6_UNLOCKED) == 0)
        {
            Disable(Tags.BUTTON_LEVEL_6);
        }

        // Level 7 unlocked/locked
        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_7_UNLOCKED) == 0)
        {
            Disable(Tags.BUTTON_LEVEL_7);
        }

        // Level 8 unlocked/locked
        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_8_UNLOCKED) == 0)
        {
            Disable(Tags.BUTTON_LEVEL_8);
        }

        // Level 9 unlocked/locked
        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_9_UNLOCKED) == 0)
        {
            Disable(Tags.BUTTON_LEVEL_9);
        }

        // Level 10 unlocked/locked
        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_10_UNLOCKED) == 0)
        {
            Disable(Tags.BUTTON_LEVEL_10);
        }

    }

}