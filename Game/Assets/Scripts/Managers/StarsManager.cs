using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsManager : MonoBehaviour
{
    private int threeStars;
    private int twoStars;
    private int oneStars;


    void Start()
    {

        threeStars = PlayerPrefs.GetInt(Keys.STAR_TIME_3);
        twoStars = PlayerPrefs.GetInt(Keys.STAR_TIME_2);
        oneStars = PlayerPrefs.GetInt(Keys.STAR_TIME_1);

        float completeTime = PlayerPrefs.GetFloat(Keys.COMPLETE_TIME);
        int caseSwitch = 0;

        if (threeStars * CompleteManager.SECONDS_TO_MICROSECONDS> completeTime)
        {
            caseSwitch = 3;
        } else if
            (twoStars * CompleteManager.SECONDS_TO_MICROSECONDS > completeTime)
        {
            caseSwitch = 2;
        } else if
            (oneStars * CompleteManager.SECONDS_TO_MICROSECONDS > completeTime)
        {
            caseSwitch = 1;
        }


        switch (caseSwitch)
        {
            case 0:
                GameObject.FindGameObjectWithTag(Tags.STAR1).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.STAR2).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.STAR3).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.NEXT_LEVEL_BUTTON).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_COMPLETE_TITLE).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_FAILED_TITLE).SetActive(true);
                PlayerPrefs.SetInt(Keys.STAR_TIME_0, 0);

                break;

            case 1:
                GameObject.FindGameObjectWithTag(Tags.STAR1).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR2).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.STAR3).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_FAILED_TITLE).SetActive(false);
                PlayerPrefs.SetInt(Keys.STAR_TIME_0, 1);

                break;

            case 2:
                GameObject.FindGameObjectWithTag(Tags.STAR1).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR2).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR3).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_FAILED_TITLE).SetActive(false);
                PlayerPrefs.SetInt(Keys.STAR_TIME_0, 1);

                break;

            case 3:
                GameObject.FindGameObjectWithTag(Tags.STAR1).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR2).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR3).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_FAILED_TITLE).SetActive(false);
                PlayerPrefs.SetInt(Keys.STAR_TIME_0, 1);

                break;

        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
