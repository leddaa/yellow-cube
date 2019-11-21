﻿using TMPro;
using UnityEngine;

public class UsernameInput : MonoBehaviour
{

    public TMP_InputField inputField;

    private void Start()
    {
        // Midlertidig
        PlayerPrefs.SetString(PrefKeys.USERNAME, "Fudgehog");
        string user = PlayerPrefs.GetString(PrefKeys.USERNAME);

        inputField.text = user;
    }

    public void SetUsername()
    {
        PlayerPrefs.SetString(PrefKeys.USERNAME, inputField.text);
    }

}
