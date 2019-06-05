using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteGame : MonoBehaviour
{

    public bool isplaying;

    void Update()
    {

        if (Input.GetKeyDown("p"))
        {
            if(isplaying == true)
            {
                isplaying = false;
               
                GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
            }
            else
            {
                isplaying = true;
                GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
            }
 
        }

    }
}
