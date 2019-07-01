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

        threeStars = PlayerPrefs.GetInt(PrefKeys.STAR_TIME_3);
        twoStars = PlayerPrefs.GetInt(PrefKeys.STAR_TIME_2);
        oneStars = PlayerPrefs.GetInt(PrefKeys.STAR_TIME_1);

        Debug.Log("threeStars time on this map: " + threeStars);
        Debug.Log("twoStars time on this map: " + twoStars);
        Debug.Log("oneStars time on this map: " + oneStars);

        float completeTime = PlayerPrefs.GetFloat(PrefKeys.COMPLETE_TIME);
        int caseSwitch = 0;

        if (threeStars > completeTime)
        {
            caseSwitch = 3;
        } else if
            (twoStars > completeTime)
        {
            caseSwitch = 2;
        } else if
            (oneStars > completeTime)
        {
            caseSwitch = 1;
        }


        switch (caseSwitch)
        {
            case 0:
                Debug.Log("Case 0, Fail! (No stars)");
                GameObject.FindGameObjectWithTag(Tags.STAR1).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.STAR2).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.STAR3).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.NEXT_LEVEL_BUTTON).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_COMPLETE_TITLE).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_FAILED_TITLE).SetActive(true);
                PlayerPrefs.SetInt(PrefKeys.STAR_TIME_0, 0);

                break;

            case 1:
                Debug.Log("Case 1, One star! Continue");
                GameObject.FindGameObjectWithTag(Tags.STAR1).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR2).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.STAR3).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_FAILED_TITLE).SetActive(false);
                PlayerPrefs.SetInt(PrefKeys.STAR_TIME_0, 1);

                break;

            case 2:
                Debug.Log("case 2, Two Stars! Continue");
                GameObject.FindGameObjectWithTag(Tags.STAR1).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR2).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR3).SetActive(false);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_FAILED_TITLE).SetActive(false);
                PlayerPrefs.SetInt(PrefKeys.STAR_TIME_0, 1);

                break;

            case 3:
                Debug.Log("case 3, Three stars! Perfect! Continue");
                GameObject.FindGameObjectWithTag(Tags.STAR1).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR2).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.STAR3).SetActive(true);
                GameObject.FindGameObjectWithTag(Tags.LEVEL_FAILED_TITLE).SetActive(false);
                PlayerPrefs.SetInt(PrefKeys.STAR_TIME_0, 1);

                break;

        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
