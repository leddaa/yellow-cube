using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteGame : MonoBehaviour
{

    public bool isplaying;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("p"))
        {
            if(isplaying == true)
            {
                isplaying = false;
                GetComponent<AudioSource>().Stop();
            }
            else
            {
                isplaying = true;
                GetComponent<AudioSource>().Play();
            }
        
            
            
        }


    }
}
