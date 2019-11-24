using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopBarManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.FindGameObjectWithTag(Tags.COINS_TEXT).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS).ToString();
        //GameObject.FindGameObjectWithTag(Tags.TOTAL_GEMS).GetComponent<TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag(Tags.DATA_STORE).GetComponent<DataStore>().GetInt(DatastoreKeys.TOTAL_YC_COINS, 0) + "";
        //GameObject.FindGameObjectWithTag(Tags.USERNAME).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString(PrefKeys.USERNAME).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
