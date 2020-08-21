using UnityEngine;
using UnityEngine.UI;

public class LevelsMenuManager : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_2_UNLOCKED) == 0)
        {
            DisableButton(Tags.BUTTON_LEVEL_2);
        }

        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_3_UNLOCKED) == 0)
        {
            DisableButton(Tags.BUTTON_LEVEL_3);
        }

        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_4_UNLOCKED) == 0)
        {
            DisableButton(Tags.BUTTON_LEVEL_4);
        }

        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_5_UNLOCKED) == 0)
        {
            DisableButton(Tags.BUTTON_LEVEL_5);
        }

        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_6_UNLOCKED) == 0)
        {
            DisableButton(Tags.BUTTON_LEVEL_6);
        }

        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_7_UNLOCKED) == 0)
        {
            DisableButton(Tags.BUTTON_LEVEL_7);
        }

        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_8_UNLOCKED) == 0)
        {
            DisableButton(Tags.BUTTON_LEVEL_8);
        }

        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_9_UNLOCKED) == 0)
        {
            DisableButton(Tags.BUTTON_LEVEL_9);
        }

        if (PlayerPrefs.GetInt(PrefKeys.LEVEL_10_UNLOCKED) == 0)
        {
            DisableButton(Tags.BUTTON_LEVEL_10);
        }
    }

    private void DisableButton(string button)
    {
        GameObject.FindGameObjectWithTag(button).GetComponent<Image>().color = new Color32(200, 200, 200, 100);
        GameObject.FindGameObjectWithTag(button).GetComponent<Button>().interactable = false;
    }
}
